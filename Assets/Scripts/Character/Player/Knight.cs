using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj, PlayerModel playerModel) : base(obj, playerModel) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new KnightFSM(this);
    }
}