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
        var damageInfo = CalcDamageInfo();
        int damage = damageInfo.damage;
        bool isCritical = damageInfo.isCritical;
        Color damageColor = isCritical ? Color.yellow : Color.red;

        enemy.TakeDamage(damage, damageColor);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);
        var damageInfo = CalcDamageInfo();
        int damage = damageInfo.damage;
        bool isCritical = damageInfo.isCritical;
        Color damageColor = isCritical ? Color.yellow : Color.red;

        player.TakeDamage(damage, damageColor);
    }
}