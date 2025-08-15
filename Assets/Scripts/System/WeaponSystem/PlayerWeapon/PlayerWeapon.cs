using UnityEngine;

public abstract class PlayerWeapon : Weapon
{
    public new PlayerWeaponModel model { get => base.model as PlayerWeaponModel; set => base.model = value; }

    //public Player player { get => base.character as Player; set => base.character = value; }

    protected GameObject rotOrigin;

    // 射击冷却计时器
    private float fireTimer;
    public bool isUsing;

    public PlayerWeapon(GameObject gameObject, Character character, PlayerWeaponModel model) : base(gameObject, character, model) { }

    protected override void OnInit()
    {
        base.OnInit();
        
        rotOrigin = UnityTools.Instance.GetTransformFromChildren(gameObject, "RotOrigin").gameObject;
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        fireTimer = 1 / model.staticAttr.fireRate;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        fireTimer += Time.deltaTime;
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