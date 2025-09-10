using UnityEngine;

public abstract class ShotGun : Weapon
{
    public new ShotGunModel model { get => base.model as ShotGunModel; protected set => base.model = value; }

    #region Attr
    public float angle => model.staticAttr.angle;

    public int bulletCount => model.staticAttr.bulletCount;
    #endregion

    public GameObject shootPoint { get; protected set; }

    public ShotGun(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }

    protected override (int damage, bool isCritical) CalcDamageInfo()
    {
        int damageOutput = Damage;
        bool isCriticalOutput = false;
        int criticalRate = CriticalRate + (owner is Player player ? player.critical : 0);

        if (Random.Range(0f, 100f) < criticalRate)
        {
            damageOutput *= 2;
            isCriticalOutput = true;
        }

        return (damageOutput, isCriticalOutput);
    }
}