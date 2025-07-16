using UnityEngine;

public abstract class PlayerWeapon : Weapon
{
    public Player player { get => base.character as Player; set => base.character = value; }
    public PlayerWeaponStaticAttr staticAttr { get; protected set; }

    protected GameObject rotOrigin;

    // 射击冷却计时器
    private float fireTimer;
    public bool isUsing;

    public PlayerWeapon(GameObject gameObject, Character character, PlayerWeaponStaticAttr staticAttr) : base(gameObject, character)
    {
        this.staticAttr = staticAttr;
    }

    protected override void OnInit()
    {
        base.OnInit();
        rotOrigin = UnityTools.Instance.GetTransformFromChildren(gameObject, "RotOrigin").gameObject;
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        fireTimer = 1 / staticAttr.fireRate;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        fireTimer += Time.deltaTime;
    }

    public void ControlWeapon(bool isAttack)
    {
        if (isAttack && fireTimer >= 1 / staticAttr.fireRate)
        {
            fireTimer = 0f;// NOTE:删除此语句解除武器限制
            OnFire();
        }
    }

    public void RotateWeapon(Vector2 weaponDir)
    {
        if (canRotate)
        {
            float angle;
            if (character.isLeft)
            {
                angle = -Vector2.SignedAngle(Vector2.left, weaponDir);
            }
            else
            {
                angle = Vector2.SignedAngle(Vector2.right, weaponDir);
            }

            rotOrigin.transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}