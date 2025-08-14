using UnityEngine;

public abstract class Effect : Item
{
    protected float effectTimer;
    protected float duration; // 特效持续时间

    public Effect(GameObject gameObject) : base(gameObject)
    {
        effectTimer = 0f;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        effectTimer += Time.deltaTime;
        if (effectTimer > duration)
        {
            Remove();
        }
    }

    public virtual void Reset(Vector3 position, Quaternion quaternion)
    {
        base.Reset();
        effectTimer = 0f;
        this.position = position;
        this.rotation = quaternion;
    }
}