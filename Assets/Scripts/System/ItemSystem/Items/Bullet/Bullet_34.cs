using UnityEngine;

public class Bullet_34 : Bullet
{
    public Bullet_34(GameObject gameObject, Character owner, int damage, int criticalRate, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, criticalRate, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }
}
