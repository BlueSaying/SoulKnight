using UnityEngine;

public class KnightIdleState : IPlayerState
{
    private Vector2 _moveDir;
    public KnightIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isIdle", true);

        rb.velocity = Vector2.zero;
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isIdle", false);
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        _moveDir.Set(player.playerInput.hor, player.playerInput.ver);

        if (_moveDir.magnitude > 0)
        {
            stateMachine.SwitchState<KnightWalkState>();
            return;
        }

    }
}