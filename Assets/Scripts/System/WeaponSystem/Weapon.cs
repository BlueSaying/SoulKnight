using System;
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
    private float fireTime => 1 / fireRate;

    public bool isUsing;

    public bool isPickUp;

    // 武器能否旋转
    protected bool canRotate;
    protected Quaternion rotation;

    private bool isInit;
    private bool isEnter;

    #region Attr
    public BuffType buffType => model.staticAttr.buffType;
    public WeaponCategory weaponCategory => model.staticAttr.weaponCategory;
    public WeaponType weaponType => model.staticAttr.weaponType;
    public QualityType qualityType => model.staticAttr.qualityType;
    public int damage => model.staticAttr.damage;
    public int energyCost => model.staticAttr.energyCost;
    public int criticalRate => model.staticAttr.criticalRate;
    public int scatterRate => model.staticAttr.scatterRate;
    public float speedDecrease => model.staticAttr.speedDecrease;
    public float fireRate => model.staticAttr.fireRate;
    public float bulletSpeed => model.staticAttr.bulletSpeed;
    #endregion

    public Weapon(GameObject gameObject, Character owner, WeaponModel model)
    {
        this.gameObject = gameObject;
        this.owner = owner;
        this.model = model;
    }

    public void ControlWeapon(bool isAttack)
    {
        // 如果不在攻击则直接返回
        if (!isAttack)
        {
            owner.CurSpeed = owner.speed;
            return;
        }

        owner.CurSpeed = owner.speed * (1 - speedDecrease);

        // 如果冷却时间到了,那么发射子弹
        if (fireTimer >= fireTime)
        {
            // 根据武器拥有者是否为玩家扣除能量值
            if (owner is Player && !TestManager.Instance.isUnlockWeapon)
            {
                Player player = owner as Player;
                if (player.CurEnergy >= energyCost)
                {
                    player.CurEnergy -= energyCost;
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