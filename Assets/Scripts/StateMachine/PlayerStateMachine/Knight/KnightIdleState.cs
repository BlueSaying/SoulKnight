using UnityEngine;

public class KnightIdleState : IPlayerState
{
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
        Vector2 moveDir = (Vector2)GameMediator.Instance.GetController<InputController>().GetMovementInput();
        //Vector2 moveDir = new Vector2(player.playerInput.hor, player.playerInput.ver);

        if (moveDir.magnitude > 0)
        {
            stateMachine.SwitchState<KnightRunState>();
            return;
        }
    }
}