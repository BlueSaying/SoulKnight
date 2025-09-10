
using UnityEngine;

public class Rifle : Weapon
{
    public new RifleModel model { get => base.model as RifleModel; protected set => base.model = value; }

    public GameObject shootPoint { get; protected set; }

    public Rifle(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }
}
