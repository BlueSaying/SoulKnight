using UnityEngine;

public class Bullet_131 : Bullet
{
    public Bullet_131(GameObject gameObject, Character owner, int damage, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, bulletSpeed, buffType) { }

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