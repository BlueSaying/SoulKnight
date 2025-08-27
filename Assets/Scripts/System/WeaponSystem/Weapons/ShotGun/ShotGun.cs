using UnityEngine;

public abstract class ShotGun : Weapon
{
    public new ShotGunModel model { get => base.model as ShotGunModel; protected set => base.model = value; }

    public int angle => model.staticAttr.angle;

    public GameObject shootPoint { get; protected set; }

    public ShotGun(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }
}