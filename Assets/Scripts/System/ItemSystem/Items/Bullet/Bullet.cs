using UnityEngine;

public abstract class Bullet : Item
{
    // 子弹飞行速度
    private float bulletSpeed;

    protected TriggerDetector triggerDetector;

    protected int damage;
    protected int criticalRate;

    public Character owner { get; protected set; }
    public BuffType buffType { get; protected set; }

    public Bullet(GameObject gameObject, Character owner, int damage, int criticalRate, float bulletSpeed, BuffType buffType) : base(gameObject)
    {
        this.owner = owner;
        this.damage = damage;
        this.criticalRate = criticalRate;
        this.bulletSpeed = bulletSpeed;
        this.buffType = buffType;
    }

    protected override void OnInit()
    {
        base.OnInit();
        try
        {
            triggerDetector = gameObject.GetComponent<TriggerDetector>();
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的TriggerDetector组件,请检查是否已经添加");
        }

        triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Obstacle", (obj) =>
        {
            OnHitObstacle();
        });

        // 根据owner是否为敌人判断
        if (owner is Player)
        {
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Enemy", (obj) =>
            {
                OnHitEnemy(obj.GetComponent<Symbol>().character as Enemy);
            });
        }
        else if (owner is Enemy)
        {
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
            {
                OnHitPlayer(obj.GetComponent<Symbol>().character as Player);
            });
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
        transform.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * bulletSpeed;
        transform.GetComponent<Collider2D>().enabled = true;
    }

    protected virtual void OnHitObstacle() { Remove(); }

    protected virtual void OnHitEnemy(Enemy enemy)
    {
        int damage = this.damage;
        Color damageColor = Color.red;
        if (Random.Range(0f, 100f) < criticalRate)
        {
            damage *= 2;
            damageColor = Color.yellow;
        }

        enemy.TakeDamage(damage, damageColor);
        enemy.AddBuff(buffType);

        Remove();
    }

    protected virtual void OnHitPlayer(Player player)
    {
        int damage = this.damage;
        Color damageColor = Color.red;
        if (Random.Range(0f, 100f) < criticalRate)
        {
            damage *= 2;
            damageColor = Color.yellow;
        }

        player.TakeDamage(damage, Color.red);
        player.AddBuff(buffType);

        Remove();
    }

    public virtual void Reset(Vector3 position, Quaternion quaternion, int damage, int criticalRate)
    {
        base.Reset();
        this.position = position;
        this.rotation = quaternion;
        this.damage = damage;
        this.criticalRate = criticalRate;
    }
}