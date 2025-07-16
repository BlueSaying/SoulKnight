using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj) : base(obj) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new KnightStateMachine(this);
    }
}