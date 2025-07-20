using UnityEngine;

public class KnightStateMachine : PlayerStateMachine
{
    public KnightStateMachine(Player player) : base(player)
    {
        SwitchState<PlayerIdleState>();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (curState is PlayerIdleState)
        {
            if (GameMediator.Instance.GetSystem<InputSystem>().GetMoveInput() != Vector2.zero)
            {
                SwitchState<PlayerRunState>();
            }
        }

        if (curState is PlayerRunState)
        {
            if (GameMediator.Instance.GetSystem<InputSystem>().GetMoveInput() == Vector2.zero)
            {
                SwitchState<PlayerIdleState>();
            }
        }
    }
}