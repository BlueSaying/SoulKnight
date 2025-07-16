using UnityEngine;

public class LittleCool : Pet
{

    public LittleCool(GameObject obj, PetStaticAttr staticAttr, Player owner) : base(obj, staticAttr, owner) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new LittleCoolStateMachine(this);
    }
}