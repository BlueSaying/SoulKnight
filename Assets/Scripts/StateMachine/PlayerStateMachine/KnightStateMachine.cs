using UnityEngine;

public class KnightStateMachine : PlayerStateMachine
{
    public KnightStateMachine(IPlayer player) : base(player)
    {
        SwitchState<PlayerIdleState>();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("角色当前状态" + currentState.ToString());
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
    }
}