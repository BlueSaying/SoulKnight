using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        // 测试代码
        Vector2 moveDir = (SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput());
        if (moveDir.magnitude > 0)
        {
            // TODO: 手感调优：自己写一个更平滑的移动函数
            rb.velocity = moveDir.normalized * player.model.staticAttr.speed;
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