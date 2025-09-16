using UnityEngine;

public class RocketLauncher : Weapon
{
    public new RocketLauncherModel model { get => base.model as RocketLauncherModel; protected set => base.model = value; }

    public GameObject shootPoint { get; protected set; }


    public RocketLauncher(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;

    }
}