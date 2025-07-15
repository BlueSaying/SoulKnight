using UnityEngine;

public class Rogue : IPlayer
{
    public Rogue(GameObject obj) : base(obj) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new RogueStateMachine(this);
    }

}