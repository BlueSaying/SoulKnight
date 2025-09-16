using UnityEngine;

public class Bullet_34 : Bullet
{
    public Bullet_34(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity, owner);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity, owner);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity, owner);
    }
}
