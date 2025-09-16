using UnityEngine;

/// <summary>
/// 火箭弹
/// </summary>
public class Bullet_10 : Bullet
{
    public Bullet_10(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        Remove();

        ItemFactory.Instance.CreateBullet(BulletType.Explosion, position, Quaternion.identity, owner, damage, isCritical, 0, buffType);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        Remove();

        ItemFactory.Instance.CreateBullet(BulletType.Explosion, position, Quaternion.identity, owner, damage, isCritical, 0, buffType);
    }

    protected override void OnHitPlayer(Player player)
    {
        Remove();

        ItemFactory.Instance.CreateBullet(BulletType.Explosion, position, Quaternion.identity, owner, damage, isCritical, 0, buffType);
    }
}