using UnityEngine;

public class Rogue : Player
{
    public Rogue(GameObject obj, PlayerStaticAttr staticAttr) : base(obj, staticAttr) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new RogueStateMachine(this);
    }

}