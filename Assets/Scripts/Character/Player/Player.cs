using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable
{
    public new PlayerModel model { get => base.model as PlayerModel; set => base.model = value; }

    protected PlayerStateMachine stateMachine;

    public List<PlayerWeapon> weapons;
    protected PlayerWeapon usingWeapon;

    public Player(GameObject obj, PlayerModel model) : base(obj, model)
    {
        this.model = model;

        weapons = new List<PlayerWeapon>();
    }

    protected override void OnInit()
    {
        base.OnInit();

        // NOTE:角色初始化时，添加阿凉为宠物
        SystemRepository.Instance.GetSystem<PlayerSystem>().AddPlayerPet(PetType.LittleCool, this);
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine.GameUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.GameUpdate();
            usingWeapon.ControlWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetKeyInput(KeyInputType.Shoot));

            Enemy cloestEnemy = AutoAimingEnemy();
            if (cloestEnemy == null)
            {
                usingWeapon.RotateWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput());
                isLeftAuto = false;
            }
            else
            {
                usingWeapon.RotateWeapon(cloestEnemy.transform.position - transform.position);
                ChangeLeft(cloestEnemy.transform.position.x < transform.position.x, true);
            }
        }

        if (SystemRepository.Instance.GetSystem<InputSystem>().GetKeyDownInput(KeyInputType.SwitchWeapon))
        {
            SwitchWeapon();
        }
    }

    public void AddWeapon(PlayerWeaponModel model)
    {
        PlayerWeapon newWeapon = WeaponFactory.Instance.GetPlayerWeapon(model, this);

        if (usingWeapon != null)
        {
            UnequipWeapon();
        }

        EquipWeapon(newWeapon);
        weapons.Add(newWeapon);
    }

    // 切换下一把武器
    public void SwitchWeapon()
    {
        // 只有武器数量大于一才可以切换武器
        if (weapons.Count <= 1) return;

        int usingWeaponIndex = 0;

        foreach (PlayerWeapon weapon in weapons)
        {
            if (weapon.isUsing)
            {
                break;
            }
            usingWeaponIndex++;
        }

        PlayerWeapon newWeapon = weapons[(usingWeaponIndex + 1) % weapons.Count];

        UnequipWeapon();
        EquipWeapon(newWeapon);
    }

    private void EquipWeapon(PlayerWeapon weapon)
    {
        weapon.isUsing = true;
        weapon.gameObject.SetActive(true);
        usingWeapon = weapon;
    }

    private void UnequipWeapon()
    {
        usingWeapon.isUsing = false;
        usingWeapon.OnExit();
        usingWeapon.gameObject.SetActive(false);
    }

    public virtual void TakeDamage(int damage, Color damageColor)
    {
        //dynamicAttr.Hp -= damage;
        Debug.Log(damage);
    }

    public virtual void Die()
    {
        EventCenter.Instance.NotifyEvent(EventType.OnPlayerDie);
    }

    // 获取自动瞄准的敌人
    public Enemy AutoAimingEnemy()
    {
        // 仅10米内的敌人可以自动瞄准
        const float AutoAimingDistance = 10f;

        Enemy output = null;
        float distance = AutoAimingDistance * AutoAimingDistance;

        foreach (var enemy in SystemRepository.Instance.GetSystem<EnemySystem>().enemies)
        {
            float x = (enemy.transform.position.x - transform.position.x);
            float y = (enemy.transform.position.y - transform.position.y);

            if (x * x + y * y < distance)
            {
                output = enemy;
                distance = x * x + y * y;
            }
        }

        return output;
    }
}