using UnityEngine;

public class Bullet_34 : PlayerBullet
{
    public Bullet_34(GameObject gameObject) : base(gameObject) { }

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

    public override void Reset()
    {
        base.Reset();
        gameObject.transform.position = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.usingWeapon.firePoint.transform.position;
    }
}
