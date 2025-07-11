using UnityEngine;

public class Rogue : IPlayer
{
    public Rogue(GameObject obj) : base(obj) { }

    protected override void OnInit()
    {
        base.OnInit();
        _playerStateMachine.SwitchState<RogueIdleState>();
    }
    
}