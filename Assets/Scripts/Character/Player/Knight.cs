using UnityEngine;

public class Knight : IPlayer
{
    public Knight(GameObject obj) : base(obj) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        playerStateMachine = new KnightStateMachine(this);
    }
}