using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj, PlayerStaticAttr staticAttr) : base(obj, staticAttr) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new KnightStateMachine(this);
    }
}