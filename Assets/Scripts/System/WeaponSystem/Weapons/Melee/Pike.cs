using UnityEngine;
using UnityEngine.UIElements;

public class Pike : Melee
{
    public Pike(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;

    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);
        // HACK
        enemy.TakeDamage(5, Color.red);
    }
}