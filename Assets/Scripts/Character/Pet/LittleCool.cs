using UnityEngine;

public class LittleCool : Pet
{

    public LittleCool(GameObject obj, PetModel model, Player owner) : base(obj, model, owner) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new LittleCoolFSM(this);
    }
}