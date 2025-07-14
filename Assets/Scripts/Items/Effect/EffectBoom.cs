using UnityEngine;

public class EffectBoom : BaseEffect
{
    public EffectBoom(GameObject gameObject) : base(gameObject) { }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        effectTimer += Time.deltaTime;
        if (effectTimer > effectTime)
        {
            Remove();
        }
    }
}