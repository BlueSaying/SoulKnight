using UnityEngine;
using UnityEngine.UIElements;

public class GoblinSpear : Melee
{
    public GoblinSpear(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;

    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        enemy.TakeDamage(model.staticAttr.damage, Color.red);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        player.TakeDamage(model.staticAttr.damage, Color.red);
    }
}