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

        int damage = Damage;
        Color damageColor = Color.red;
        int criticalRate = CriticalRate + (owner is Player player ? player.critical : 0);
        if (Random.Range(0f, 100f) < criticalRate)
        {
            damage *= 2;
            damageColor = Color.yellow;
        }

        enemy.TakeDamage(damage, damageColor);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        int damage = Damage;
        Color damageColor = Color.red;
        int criticalRate = CriticalRate + (owner is Player player_ ? player_.critical : 0);
        if (Random.Range(0f, 100f) < criticalRate)
        {
            damage *= 2;
            damageColor = Color.yellow;
        }

        player.TakeDamage(damage, damageColor);
    }
}