using UnityEngine;

public abstract class ShotGun : Weapon
{
    public new ShotGunModel model { get => base.model as ShotGunModel; protected set => base.model = value; }

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
}