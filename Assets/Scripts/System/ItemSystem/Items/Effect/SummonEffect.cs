using UnityEngine;

public class SummonEffect : Effect
{
    public SummonEffect(GameObject gameObject, Character owner) : base(gameObject, owner)
    {
        duration = 1f;
    }
}