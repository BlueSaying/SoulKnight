using UnityEngine;
public class RogueIdleState : IPlayerState
{
    public RogueIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

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
        Vector2 moveDir = ((Vector2)GameMediator.Instance.GetController<InputController>().GetMovementInput());

        if (moveDir.magnitude > 0)
        {
            stateMachine.SwitchState<RogueRunState>();
            return;
        }
    }
}