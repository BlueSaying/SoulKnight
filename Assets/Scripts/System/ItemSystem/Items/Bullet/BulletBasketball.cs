using UnityEngine;

public class BulletBasketball : Bullet
{
    private const int BounceTimes = 3;
    private int bounceCount = 0;

    protected CollisionDetector collisionDetector;

    public BulletBasketball(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnInit()
    {
        base.OnInit();
        try
        {
            collisionDetector = gameObject.GetComponent<CollisionDetector>();
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的CollisionDetector组件,请检查是否已经添加");
        }

        collisionDetector.AddCollisionListener(CollisionEventType.OnCollisionEnter2D, "Obstacle", (obj) =>
        {
            bounceCount++;

            if (bounceCount >= BounceTimes)
            {
                base.OnHitObstacle();
                ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity);
            }
        });

        // 根据owner是否为敌人判断
        //if (owner is Player)
        //{
        //    collisionDetector.AddCollisionListener(CollisionEventType.OnCollisionEnter2D, "Enemy", (obj) =>
        //    {
        //        OnHitEnemy(obj.GetComponent<Symbol>().character as Enemy);
        //    });
        //}
        //else if (owner is Enemy)
        //{
        //    collisionDetector.AddCollisionListener(CollisionEventType.OnCollisionEnter2D, "Player", (obj) =>
        //    {
        //        OnHitPlayer(obj.GetComponent<Symbol>().character as Player);
        //    });
        //}
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        base.OnHitEnemy(enemy);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity);
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        ItemFactory.Instance.CreateEffect(EffectType.BoomEffectYellow, position, Quaternion.identity);
    }

    public override void Reset(Vector3 position, Quaternion quaternion, int damage, bool isCritical, BuffType buffType)
    {
        base.Reset(position, quaternion, damage, isCritical, buffType);
        bounceCount = 0;
    }
}