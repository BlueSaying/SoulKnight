using UnityEngine;

public class Bullet_105 : Bullet
{
    public Bullet_105(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectRed, position, Quaternion.identity);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectRed, position, Quaternion.identity);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectRed, position, Quaternion.identity);
    }
}
