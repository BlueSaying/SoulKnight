using UnityEngine;

public class PlayerRunState : IPlayerState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        // 测试代码
        Vector2 moveDir= ((Vector2)GameMediator.Instance.GetController<InputController>().GetMoveInput());
        if (moveDir.magnitude > 0)
        {
            // TODO: 手感调优：自己写一个更平滑的移动函数
            rb.velocity = moveDir.normalized * 8;
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