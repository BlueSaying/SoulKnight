using UnityEngine;

public class Bullet_34 : PlayerBullet
{
    public Bullet_34(GameObject gameObject) : base(gameObject) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        BoomEffect effect = ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity) as BoomEffect;
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK
        enemy.TakeDamage(5, Color.red);

        BoomEffect effect = ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity) as BoomEffect;
    }
}
