using UnityEngine;

public abstract class Bullet : Item
{
    // 子弹飞行速度
    private const float speed = 30f;

    protected TriggerDetector triggerDetector;

    public Bullet(GameObject gameObject) : base(gameObject) { }
    
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
    }

    public override void OnEnter()
    {
        base.OnEnter();
        transform.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * speed;
        transform.GetComponent<BoxCollider2D>().enabled = true;
        //Debug.Log(ToString());
    }

    protected virtual void OnHitObstacle() { Remove(); }
}