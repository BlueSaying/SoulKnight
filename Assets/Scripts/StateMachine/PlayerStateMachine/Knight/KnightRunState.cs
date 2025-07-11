using UnityEngine;

public class KnightRunState : IPlayerState
{
    public KnightRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        // 测试代码
        Vector2 moveDir= new Vector2(player.playerInput.hor, player.playerInput.ver);
        if (moveDir.magnitude > 0)
        {
            // TODO: 手感调优：自己写一个更平滑的移动函数
            rb.velocity = moveDir.normalized * 8;
        }
        else if (moveDir.magnitude == 0)
        {
            stateMachine.SwitchState<KnightIdleState>();
            return;
        }
        if (moveDir.x > 0)
        {
            player.isLeft = false;
        }
        else if (moveDir.x < 0)
        {
            player.isLeft = true;
        }
    }

}