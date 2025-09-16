using UnityEngine;

public class BoomEffectYellow : Effect
{
    public BoomEffectYellow(GameObject gameObject, Character owner) : base(gameObject, owner)
    {
        duration = 0.5f;
    }
}