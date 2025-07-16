using UnityEngine;

public class LittleCool : BasePet
{

    public LittleCool(GameObject obj, Player owner) : base(obj, owner) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new LittleCoolStateMachine(this);
    }
}