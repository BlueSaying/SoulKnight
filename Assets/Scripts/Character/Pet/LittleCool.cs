using UnityEngine;

public class LittleCool : Pet
{

    public LittleCool(GameObject obj, PetModel model, Player owner) : base(obj, model, owner) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new LittleCoolFSM(this);
    }
}