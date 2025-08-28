using UnityEngine;

public class GoblinSpear : Melee
{
    public GoblinSpear(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        enemy.TakeDamage(Damage, Color.red);
        enemy.AddBuff(BuffType.Burn, 2f);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        player.TakeDamage(Damage, Color.red);
    }   
}