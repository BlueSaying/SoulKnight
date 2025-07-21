using UnityEngine;

public enum WeaponCategory
{
    Pistol,
    Rifle,
    Missile,
    Staff,
    Other,
    Shotgun,
    ThrownWeapon,
    Bow,
    CloseCombat,
}

public enum QualityType
{
    White,
    Green,
    Blue,
    Purple,
    Orange,
    Red,
    colorful,
}

public abstract class Weapon
{
    public WeaponModel model { get; protected set; }

    // 武器的游戏物体
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    protected Character character; // 代表哪个角色拥有该武器
    protected GameObject firePoint;

    // 武器能否旋转
    protected bool canRotate;

    private bool isInit;
    private bool isEnter;
    public Weapon(GameObject gameObject, Character character, WeaponModel model)
    {
        this.gameObject = gameObject;
        this.character = character;
        this.model = model;

        //HACK
        canRotate = true;
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

    protected virtual void OnInit()
    {
        firePoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "FirePoint").gameObject;
    }

    // 每次切换至此武器时调用一次
    protected virtual void OnEnter() { }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnExit()
    {
        isEnter = false;
    }

    // 发射时执行
    protected virtual void OnFire() { }
}