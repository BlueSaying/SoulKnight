using UnityEngine;

public class Bullet_5 : BasePlayerBullet
{
    public Bullet_5(GameObject gameObject) : base(gameObject) { }

    protected override void OnHitObstacle()
    {
        base.OnHitObstacle();

        EffectBoom effect = ItemFactory.Instance.CreateEffect(EffectType.EffectBoom, position, Quaternion.identity) as EffectBoom;
        effect.ManagedToController();
    }

}
