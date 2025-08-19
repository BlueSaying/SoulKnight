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

        enemy.TakeDamage(model.staticAttr.damage, new Color(1f, 0.5f, 0f));
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        player.TakeDamage(model.staticAttr.damage, Color.red);
    }
}