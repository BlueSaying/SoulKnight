using UnityEngine;

public abstract class RogueState : PlayerState
{
    public RogueState(PlayerFSM fsm) : base(fsm) { }


}

public class RogueIdleState : KnightState
{
    public RogueIdleState(PlayerFSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isIdle", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isIdle", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (rb.velocity != Vector2.zero)
        {
            fsm.SwitchState<RogueRunState>();
        }
    }
}

public class RogueRunState : KnightState
{
    public RogueRunState(PlayerFSM fsm) : base(fsm) { }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (moveDir.x > 0)
        {
            player.ChangeLeft(false, false);
        }
        else if (moveDir.x < 0)
        {
            player.ChangeLeft(true, false);
        }

        if (rb.velocity == Vector2.zero)
        {
            fsm.SwitchState<RogueIdleState>();
        }
    }
}

public class RogueRollState : PlayerState
{
    public RogueRollState(PlayerFSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetTrigger("isRoll");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}