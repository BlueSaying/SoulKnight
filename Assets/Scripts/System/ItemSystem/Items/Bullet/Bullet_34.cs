using UnityEngine;

public class Bullet_34 : Bullet
{
    public Bullet_34(GameObject gameObject, Character owner, int damage) : base(gameObject, owner, damage) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK
        enemy.TakeDamage(5, new Color(1f, 0.4f, 0f));
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        // HACK:后期将伤害作为该函数的参数传入
        player.TakeDamage(5, Color.red);
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }
}
