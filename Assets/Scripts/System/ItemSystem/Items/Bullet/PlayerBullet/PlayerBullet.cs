using UnityEngine;

public abstract class PlayerBullet : Bullet
{
    public PlayerBullet(GameObject gameObject) : base(gameObject) { }

    protected override void OnInit()
    {
        base.OnInit();
        triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Enemy", (obj) =>
        {
            OnHitEnemy(obj.GetComponent<Symbol>().character as Enemy);
        });
    }

    protected virtual void OnHitEnemy(Enemy enemy) { Remove(); }

    public virtual void Reset(Vector3 position, Quaternion quaternion)
    {
        base.Reset();
        this.position = position;
        this.rotation = quaternion;
    }
}