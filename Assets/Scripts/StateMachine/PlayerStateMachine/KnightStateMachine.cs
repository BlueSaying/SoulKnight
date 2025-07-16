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
        //Debug.Log("角色当前状态" + currentState.ToString());
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
    }
}