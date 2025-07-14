using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
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
}