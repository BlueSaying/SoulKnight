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
    public bool isUsing;

    // 武器能否旋转
    protected bool canRotate;

    private bool isInit;
    private bool isEnter;
    public Weapon(GameObject gameObject, Character owner, WeaponModel model)
    {
        this.gameObject = gameObject;
        this.owner = owner;
        this.model = model;
    }

    public void ControlWeapon(bool isAttack)
    {
        if (isAttack && fireTimer >= 1 / model.staticAttr.fireRate)
        {
            if (!TestManager.Instance.isUnlockWeapon) fireTimer = 0f;
            else fireTimer = 0.9f / model.staticAttr.fireRate;  // 10倍射速
            OnFire();
        }
    }

    public void RotateWeapon(Vector2 weaponDir)
    {
        if (!canRotate) return;

        float angle;
        if (owner.isLeft)
        {
            angle = -Vector2.SignedAngle(Vector2.left, weaponDir);
        }
        else
        {
            angle = Vector2.SignedAngle(Vector2.right, weaponDir);
        }

        rotOrigin.transform.localRotation = Quaternion.Euler(0, 0, angle);
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