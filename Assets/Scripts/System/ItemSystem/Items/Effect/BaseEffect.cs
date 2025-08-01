using UnityEngine;

public class BaseEffect : Item
{
    private float effectTimer;
    protected float duration; // 特效持续时间

    public BaseEffect(GameObject gameObject) : base(gameObject)
    {
        effectTimer = 0f;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log(effectTimer + "/" + duration);
        effectTimer += Time.deltaTime;
        if (effectTimer > duration)
        {
            Remove();
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
        Debug.Log("Deleting");
        Object.Destroy(gameObject);
    }
}