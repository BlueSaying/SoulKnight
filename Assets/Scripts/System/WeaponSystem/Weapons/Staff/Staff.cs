using UnityEngine;

public abstract class Staff : Weapon
{
    public GameObject shootPoint { get; protected set; }

    public Staff(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = false;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }
}