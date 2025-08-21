using UnityEngine;

public abstract class KnightState : PlayerState
{
    public KnightState(PlayerFSM fsm) : base(fsm) { }
}

public class KnightIdleState : KnightState
{
    public KnightIdleState(PlayerFSM fsm) : base(fsm) { }

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
            fsm.SwitchState<KnightRunState>();
        }
    }
}

public class KnightRunState : KnightState
{
    public KnightRunState(PlayerFSM fsm) : base(fsm) { }

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
            fsm.SwitchState<KnightIdleState>();
        }
    }
}