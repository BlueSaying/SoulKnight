using UnityEngine;

public abstract class Weapon
{
    public WeaponModel model { get; protected set; }

    // 武器的游戏物体
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Character owner { get; protected set; } // 代表哪个角色拥有该武器
    public GameObject rotOrigin { get; protected set; }

    protected Animator animator;

    // 射击冷却计时器
    private float fireTimer;
    private float fireTime => 1 / FireRate;

    public bool isUsing;

    public bool isPickUp;

    // 武器能否旋转
    protected bool canRotate;
    protected Quaternion rotation;

    private bool isInit;
    private bool isEnter;

    #region Attr
    public BuffType BuffType => model.staticAttr.buffType;
    public WeaponCategory WeaponCategory => model.staticAttr.weaponCategory;
    public WeaponType WeaponType => model.staticAttr.weaponType;
    public QualityType QualityType => model.staticAttr.qualityType;
    public int Damage => model.staticAttr.damage;
    public int EnergyCost => model.staticAttr.energyCost;
    public int CriticalRate => model.staticAttr.criticalRate;
    public int ScatterRate => model.staticAttr.scatterRate;
    public float SpeedDecrease => model.staticAttr.speedDecrease;
    public float FireRate => model.staticAttr.fireRate;
    public float BulletSpeed => model.staticAttr.bulletSpeed;
    #endregion

    public Weapon(GameObject gameObject, Character owner, WeaponModel model)
    {
        this.gameObject = gameObject;
        this.owner = owner;
        this.model = model;
    }

    // 记录上一帧是否在攻击
    protected bool IsAttack { get; private set; }
    public virtual void ControlWeapon(bool isAttack)
    {
        // 如果上一帧攻击而这一帧没有在攻击
        if (!isAttack && IsAttack)
        {
            owner.CurSpeed.AddPercentModifier(SpeedDecrease);
        }
        else if (isAttack && !IsAttack)
        {
            owner.CurSpeed.AddPercentModifier(-SpeedDecrease);
        }
        IsAttack = isAttack;

        // 如果不在攻击则直接返回，无后续处理
        if (!isAttack) return;

        // 如果冷却时间到了,那么发射子弹
        if (fireTimer >= fireTime)
        {
            // 根据武器拥有者是否为玩家扣除能量值
            if (owner is Player && !TestManager.Instance.isUnlockWeapon)
            {
                Player player = owner as Player;
                if (player.CurEnergy.Value >= EnergyCost)
                {
                    player.CurEnergy.AddFlatModifier(-EnergyCost);
                }
                else
                {
                    return;
                }
            }

            if (TestManager.Instance.isUnlockWeapon) fireTimer = 0.9f * fireTime;  // 10倍射速
            else fireTimer = 0f;
            OnFire();
        }
    }

    public void RotateWeapon(Vector2 weaponDir)
    {
        float angleY, angleZ;
        if (owner.isLeft)
        {
            angleY = -180;
            angleZ = -Vector2.SignedAngle(Vector2.left, weaponDir);
        }
        else
        {
            angleY = 0;
            angleZ = Vector2.SignedAngle(Vector2.right, weaponDir);
        }

        rotation = Quaternion.Euler(0, angleY, angleZ);

        // 如果可以旋转那么便修改武器表现
        if (canRotate)
        {
            rotOrigin.transform.rotation = rotation;
        }
    }

    public virtual void OnExit()
    {
        isEnter = false;

        // 退出时要把攻击减少的速度加回去
        if (IsAttack)
        {
            owner.CurSpeed.AddPercentModifier(SpeedDecrease);
        }
    }

    protected virtual void OnInit()
    {
        animator = gameObject.GetComponent<Animator>();
        rotOrigin = UnityTools.Instance.GetTransformFromChildren(gameObject, "RotOrigin").gameObject;
    }

    // 每次切换至此武器时调用一次
    protected virtual void OnEnter()
    {
        fireTimer = 0;

        IsAttack = false;
    }

    public virtual void OnFixedUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }

        fireTimer += Time.deltaTime;
    }

    // 武器攻击时执行
    protected virtual void OnFire() { }
}