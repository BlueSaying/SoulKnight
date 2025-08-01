using UnityEngine;

public class Bullet_5 : PlayerBullet
{
    public Bullet_5(GameObject gameObject) : base(gameObject) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        // TODO:后期将effectType设为Bullet类的属性
        EffectBoom effect = ItemFactory.Instance.CreateEffect(EffectType.EffectBoom, position, Quaternion.identity) as EffectBoom;
        effect.ManagedToController();
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK:后期将伤害作为该函数的参数传入
        enemy.TakeDamage(5, Color.red);

        EffectBoom effect = ItemFactory.Instance.CreateEffect(EffectType.EffectBoom, position, Quaternion.identity) as EffectBoom;
        effect.ManagedToController();
    }
}
