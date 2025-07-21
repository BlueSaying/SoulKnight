using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj, PlayerModel playerModel) : base(obj, playerModel) { }

    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new KnightStateMachine(this);
    }
}