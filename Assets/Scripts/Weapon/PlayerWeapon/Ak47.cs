using UnityEngine;

public class Ak47 : IPlayerWeapon
{
    public Ak47(GameObject gameObject, ICharacter character) : base(gameObject, character) { }

    public override void OnExit()
    {
        base.OnExit();
    }

    protected override void OnEnter()
    {
        base.OnEnter();
    }

    protected override void OnFire()
    {
        base.OnFire();
    }

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
    }
}