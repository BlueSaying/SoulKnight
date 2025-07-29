using UnityEngine;

public class Bullet : Item
{
    protected TriggerDetector triggerDetector;

    // 子弹飞行速度
    private const float speed = 30f;

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

    protected override void OnExit()
    {
        base.OnExit();
        Object.Destroy(gameObject);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        // TODO:后期改为BaseBullet.speed
        transform.position += rotation * Vector2.right * speed * Time.deltaTime;
    }

    protected virtual void OnHitObstacle() { Remove(); }
}