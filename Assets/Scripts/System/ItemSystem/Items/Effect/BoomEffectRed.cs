using UnityEngine;

public class BoomEffectRed : Effect
{
    public BoomEffectRed(GameObject gameObject, Character owner) : base(gameObject, owner)
    {
        duration = 0.5f;
    }
}