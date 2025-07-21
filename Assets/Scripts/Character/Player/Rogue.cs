using UnityEngine;

public class Rogue : Player
{
    public Rogue(GameObject obj, PlayerModel playerModel) : base(obj, playerModel) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new RogueStateMachine(this);
    }

}