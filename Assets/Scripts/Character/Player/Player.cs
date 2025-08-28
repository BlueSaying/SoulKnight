using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character, IDamageable
{
    public new PlayerModel model { get => base.model as PlayerModel; set => base.model = value; }

    protected PlayerFSM stateMachine;

    public List<GameObject> pickUpableList;
    public List<Weapon> weapons;
    public Weapon usingWeapon { get; protected set; }

    private CinemachineFramingTransposer cinemachineFramingTransposer;

    #region Attr
    // 静态属性
    public PlayerType playerType => model.staticAttr.playerType;
    public WeaponType defaultWeaponType => model.staticAttr.defaultWeaponType;
    public int maxArmor => model.staticAttr.maxArmor;
    public int maxEnergy => model.staticAttr.maxEnergy;
    public int critical => model.staticAttr.critical;
    public int handAttackDamage => model.staticAttr.handAttackDamage;
    public float fightingSpeed => model.staticAttr.fightingSpeed;
    public float finishFightingSpeed => model.staticAttr.finishFightingSpeed;
    public float armorRecoveryTime => model.staticAttr.armorRecoveryTime;
    public float hurtArmorRecoveryTime => model.staticAttr.hurtArmorRecoveryTime;
    public float hurtInvincibleTime => model.staticAttr.hurtInvincibleTime;

    // 动态属性
    public PlayerSkinType PlayerSkinType
    {
        get
        {
            return model.dynamicAttr.playerSkinType;
        }
        protected set
        {
            model.dynamicAttr.playerSkinType = value;
        }
    }

    public new int CurHP
    {
        get
        {
            return Mathf.RoundToInt(model.dynamicAttr.curHP.Value);
        }
        set
        {
            model.dynamicAttr.curHP.AddModifier(new FlatModifier(value - CurHP));
            EventCenter.Instance.NotifyEvent(EventType.UpdateBattlePanel);
        }
    }
    public int CurArmor
    {
        get
        {
            return Mathf.RoundToInt(model.dynamicAttr.curArmor.Value);
        }
        set
        {
            model.dynamicAttr.curArmor.AddModifier(new FlatModifier(value - CurArmor));
            EventCenter.Instance.NotifyEvent(EventType.UpdateBattlePanel);
        }
    }

    public int CurEnergy
    {
        get
        {
            return Mathf.RoundToInt(model.dynamicAttr.curEnergy.Value);
        }
        set
        {
            model.dynamicAttr.curEnergy.AddModifier(new FlatModifier(value - CurEnergy));
            EventCenter.Instance.NotifyEvent(EventType.UpdateBattlePanel);
        }
    }
    #endregion

    private float hurtArmorRecoveryTimer;
    private float armorRecoveryTimer;
    private float hurtInvincibleTimer;

    public Player(GameObject obj, PlayerModel model) : base(obj, model)
    {
        this.model = model;
        model.Recover();

        pickUpableList = new List<GameObject>();
        weapons = new List<Weapon>();

        hurtArmorRecoveryTimer = 0f;
        armorRecoveryTimer = 0f;
        hurtInvincibleTimer = 0f;
    }

    protected override void OnInit()
    {
        base.OnInit();

        cinemachineFramingTransposer = GameObject.Find("FollowCamera").
            GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();

        // NOTE:角色初始化时，添加阿凉为宠物
        //SystemRepository.Instance.GetSystem<PlayerSystem>().AddPlayerPet(PetType.LittleCool, this);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        stateMachine?.OnFixedUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.OnFixedUpdate();
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        stateMachine?.OnUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.OnUpdate();
            usingWeapon.ControlWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetKeyInput(KeyInputType.Shoot));

            // 尝试自动瞄准最近敌人
            TryAutoAimingEnemy();
        }

        if (SystemRepository.Instance.GetSystem<InputSystem>().GetKeyDownInput(KeyInputType.SwitchWeapon))
        {
            SwitchWeapon();
        }

        hurtArmorRecoveryTimer += Time.deltaTime;
        if (hurtArmorRecoveryTimer > hurtArmorRecoveryTime && CurArmor < maxArmor)
        {
            if (armorRecoveryTimer > armorRecoveryTime)
            {
                CurArmor++;
                armorRecoveryTimer = 0f;
            }
            else
            {
                armorRecoveryTimer += Time.deltaTime;
            }
        }

        hurtInvincibleTimer += Time.deltaTime;
    }

    public void AddWeapon(WeaponModel model)
    {
        Weapon newWeapon = WeaponFactory.GetWeapon(model, this);
        newWeapon.isPickUp = true;

        if (usingWeapon != null)
        {
            UnequipWeapon();
        }

        EquipWeapon(newWeapon);
        weapons.Add(newWeapon);
    }

    // 切换下一把武器
    private void SwitchWeapon()
    {
        // 只有武器数量大于一才可以切换武器
        if (weapons.Count <= 1) return;

        int index = 0;

        foreach (Weapon weapon in weapons)
        {
            if (weapon.isUsing)
            {
                break;
            }
            index++;
        }

        Weapon newWeapon = weapons[(index + 1) % weapons.Count];

        UnequipWeapon();
        EquipWeapon(newWeapon);
    }

    private void EquipWeapon(Weapon weapon)
    {
        weapon.isUsing = true;
        weapon.gameObject.SetActive(true);
        usingWeapon = weapon;

        // 播放音效
        AudioManager.Instance.PlaySound(AudioType.Others, AudioName.fx_switch);
    }

    private void UnequipWeapon()
    {
        usingWeapon.isUsing = false;
        usingWeapon.OnExit();
        usingWeapon.gameObject.SetActive(false);
    }

    public virtual void TakeDamage(int damage, Color damageColor)
    {
        if (damage <= 0 || hurtInvincibleTimer < hurtInvincibleTime) return;

        // 护甲恢复计时器归零
        hurtArmorRecoveryTimer = 0f;
        armorRecoveryTimer = 0f;
        hurtInvincibleTimer = 0f;

        // 弹出伤害值
        Transform damageNumPoint = transform.Find("DamageNumPoint");
        ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint.position, damage, damageColor);

        // 播放音效
        if (PlayerSkinType == PlayerSkinType.RogueKun)
        {
            AudioManager.Instance.PlaySound(AudioType.Hurt, AudioName.niganma);
        }
        else
        {
            AudioManager.Instance.PlaySound(AudioType.Hurt, (AudioName)(AudioName.fx_hit_p1 + Random.Range(0, 5)));
        }

        // 优先扣除护盾值
        if (CurArmor >= damage)
        {
            CurArmor -= damage;
            damage = 0;
        }
        else
        {
            damage -= CurArmor;
            CurArmor = 0;
        }

        // 判断剩余伤害是否要继续扣除血量
        if (damage <= 0) return;

        if (CurHP >= damage)
        {
            CurHP -= damage;
            damage = 0;
        }
        else
        {
            damage -= CurHP;
            CurHP = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        if (isDead) return;
        isDead = true;

        EventCenter.Instance.NotifyEvent(EventType.OnPlayerDie);
        Debug.Log("DIE");
    }

    // 获取自动瞄准的敌人
    public void TryAutoAimingEnemy()
    {
        // 仅10米内的敌人可以自动瞄准
        const float AutoAimingDistance = 10f;

        Enemy cloestEnemy = null;
        float distance = AutoAimingDistance * AutoAimingDistance;

        // 遍历所有敌人
        foreach (var enemy in SystemRepository.Instance.GetSystem<EnemySystem>().enemies)
        {
            float x = (enemy.transform.position.x - transform.position.x);
            float y = (enemy.transform.position.y - transform.position.y);

            if (x * x + y * y < distance)
            {
                cloestEnemy = enemy;
                distance = x * x + y * y;
            }
        }

        if (cloestEnemy == null)
        {
            usingWeapon.RotateWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput());
            isLeftAuto = false;

            // 修改VCam
            cinemachineFramingTransposer.m_TrackedObjectOffset = new Vector2(0.5f, 0);
        }
        else
        {
            Vector2 dir = (cloestEnemy.transform.position - transform.position).normalized;
            usingWeapon.RotateWeapon(dir);
            ChangeLeft(cloestEnemy.transform.position.x < transform.position.x, true);

            // 修改VCam
            cinemachineFramingTransposer.m_TrackedObjectOffset =
                new Vector2(Mathf.Abs(dir.x), dir.y);
        }
    }
}