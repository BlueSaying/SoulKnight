using UnityEngine;

public class Bullet_5 : Bullet
{
    public Bullet_5(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        // TODO:后期将effectType设为Bullet类的属性
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
