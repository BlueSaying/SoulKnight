using UnityEngine;

public class Knight : IPlayer
{
    public Knight(GameObject obj) : base(obj) { }
    protected override void OnInit()
    {
        base.OnInit();
        _playerStateMachine.SwitchState<KnightIdleState>();
    }
    
}