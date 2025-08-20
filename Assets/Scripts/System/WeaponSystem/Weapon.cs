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
    private float fireTime => 1 / model.staticAttr.fireRate;
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
    public int angle => model.staticAttr.angle;
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
        if (isAttack && fireTimer >= fireTime)
        {
            if (!TestManager.Instance.isUnlockWeapon) fireTimer = 0f;
            else fireTimer = 0.9f * fireTime;  // 10倍射速
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

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        OnUpdate();
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
        fireTimer = 1 / model.staticAttr.fireRate;
    }

    protected virtual void OnUpdate()
    {
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