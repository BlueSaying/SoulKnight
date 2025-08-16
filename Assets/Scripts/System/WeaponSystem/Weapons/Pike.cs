using UnityEngine;

public class Pike : Weapon
{
    public Pike(GameObject gameObject, Character character, WeaponModel model) : base(gameObject, character, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        animator.SetTrigger("Attack");
    }
}