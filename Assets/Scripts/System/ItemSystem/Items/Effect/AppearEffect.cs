using UnityEngine;

public class AppearEffect : Effect
{
    public AppearEffect(GameObject gameObject, Character owner) : base(gameObject, owner) 
    {
        duration = 0.416667f;
    }
}
