
using UnityEngine;

public abstract class Pistol : Weapon
{
    public new PistolModel model { get => base.model as PistolModel; protected set => base.model = value; }

    public GameObject shootPoint { get; protected set; }

    protected Pistol(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }
}
