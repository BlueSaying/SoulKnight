using UnityEngine;

public abstract class Bullet : Item
{
    // 子弹飞行速度
    private const float speed = 30f;

    protected TriggerDetector triggerDetector;

    public Character owner { get; protected set; }

    public Bullet(GameObject gameObject, Character owner) : base(gameObject)
    {
        this.owner = owner;
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

        // TODO:根据owner是否为敌人判断
        triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Enemy", (obj) =>
        {
            OnHitEnemy(obj.GetComponent<Symbol>().character as Enemy);
        });
    }

    public override void OnEnter()
    {
        base.OnEnter();
        transform.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * speed;
        transform.GetComponent<BoxCollider2D>().enabled = true;
        //Debug.Log(ToString());
    }

    protected virtual void OnHitObstacle() { Remove(); }

    protected virtual void OnHitEnemy(Enemy enemy) { Remove(); }

    public virtual void Reset(Vector3 position, Quaternion quaternion)
    {
        base.Reset();
        this.position = position;
        this.rotation = quaternion;
    }
}