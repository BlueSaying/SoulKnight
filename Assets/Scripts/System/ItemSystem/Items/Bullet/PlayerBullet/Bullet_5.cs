using UnityEngine;

public class Bullet_5 : PlayerBullet
{
    public Bullet_5(GameObject gameObject) : base(gameObject) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        // TODO:后期将effectType设为Bullet类的属性
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        // HACK:后期将伤害作为该函数的参数传入
        enemy.TakeDamage(5, Color.red);
        
        ItemFactory.Instance.CreateEffect(EffectType.BoomEffect, position, Quaternion.identity);
    }

    public override void Reset()
    {
        base.Reset();
        gameObject.transform.position = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.usingWeapon.firePoint.transform.position;
    }
}
