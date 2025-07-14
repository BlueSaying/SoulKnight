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

        if (currentState is PlayerIdleState)
        {
            if (GameMediator.Instance.GetController<InputController>().GetMoveInput() != Vector2.zero)
            {
                SwitchState<PlayerRunState>();
            }
        }
        if (currentState is PlayerRunState)
        {
            if (GameMediator.Instance.GetController<InputController>().GetMoveInput() == Vector2.zero)
            {
                SwitchState<PlayerIdleState>();
            }
        }
        if(currentState is PlayerRollState)
        {
            
        }
    }
}