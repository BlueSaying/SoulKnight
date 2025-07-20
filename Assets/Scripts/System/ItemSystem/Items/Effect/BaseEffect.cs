using UnityEngine;

public class BaseEffect : Item
{
    protected float effectTimer;
    protected float duration; // 特效持续时间

    public BaseEffect(GameObject gameObject) : base(gameObject)
    {
        effectTimer = 0f;
        duration = 0.5f;
    }

    protected override void OnExit()
    {
        base.OnExit();

        Object.Destroy(gameObject);
    }
}