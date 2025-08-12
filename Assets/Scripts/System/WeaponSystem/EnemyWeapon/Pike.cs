using UnityEngine;

public class Pike : PlayerWeapon
{
    public Pike(GameObject gameObject, Character character, PlayerWeaponModel model) : base(gameObject, character, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        animator.SetTrigger("Attack");
    }
}