using UnityEngine;

public class KnightWalkState : IPlayerState
{
    private Vector2 _moveDir;
    public KnightWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        // 测试代码
        _moveDir.Set(player.playerInput.hor, player.playerInput.ver);
        if (_moveDir.magnitude > 0)
        {
            // TODO: 手感调优：自己写一个更平滑的移动函数
            rb.velocity = _moveDir.normalized * 8;
        }
        else if (_moveDir.magnitude == 0)
        {
            stateMachine.SwitchState<KnightIdleState>();
            return;
        }
        if (_moveDir.x > 0)
        {
            player.isLeft = false;
        }
        else if (_moveDir.x < 0)
        {
            player.isLeft = true;
        }
    }

}