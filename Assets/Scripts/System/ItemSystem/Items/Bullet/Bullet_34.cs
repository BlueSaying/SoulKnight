using UnityEngine;

public class Bullet_34 : Bullet
{
    public Bullet_34(GameObject gameObject, Character owner) : base(gameObject, owner) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK
        enemy.TakeDamage(5, Color.red);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    
}
