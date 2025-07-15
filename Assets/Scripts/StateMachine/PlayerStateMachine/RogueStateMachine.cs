using UnityEngine;

public class RogueStateMachine : PlayerStateMachine
{
    public RogueStateMachine(IPlayer player) : base(player)
    {
        SwitchState<PlayerIdleState>();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (curState is PlayerIdleState)
        {
            if (GameMediator.Instance.GetController<InputController>().GetMoveInput() != Vector2.zero)
            {
                SwitchState<PlayerRunState>();
            }
        }
        if (curState is PlayerRunState)
        {
            if (GameMediator.Instance.GetController<InputController>().GetMoveInput() == Vector2.zero)
            {
                SwitchState<PlayerIdleState>();
            }
        }
        if(curState is PlayerRollState)
        {
            
        }
    }
}