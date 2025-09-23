using UnityEngine;

public class Bullet_38 : Bullet
{
    // 子弹旋转角速度
    private const float w = 2 * Mathf.PI * Mathf.Rad2Deg;

    public Bullet_38(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        rotation *= Quaternion.Euler(0, 0, w * Time.fixedDeltaTime);
    }

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