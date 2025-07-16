using UnityEngine;

public class Bullet_5 : PlayerBullet
{
    public Bullet_5(GameObject gameObject) : base(gameObject) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        EffectBoom effect = ItemFactory.Instance.CreateEffect(EffectType.EffectBoom, position, Quaternion.identity) as EffectBoom;
        effect.ManagedToController();
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK
        //enemy.TakeDamage(5);

        EffectBoom effect = ItemFactory.Instance.CreateEffect(EffectType.EffectBoom, position, Quaternion.identity) as EffectBoom;
        effect.ManagedToController();
    }
}
