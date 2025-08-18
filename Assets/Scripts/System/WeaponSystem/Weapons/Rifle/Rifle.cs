
using UnityEngine;

public class Rifle : Weapon
{
    public GameObject shootPoint { get; protected set; }

    public Rifle(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }
}
