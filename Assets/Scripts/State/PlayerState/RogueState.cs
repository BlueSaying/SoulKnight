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

        if (SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput() != Vector2.zero)
        {
            fsm.SwitchState<RogueRunState>();
        }
    }
}

public class RogueRunState : KnightState
{
    public RogueRunState(PlayerFSM fsm) : base(fsm) { }

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
        else
        {
            fsm.SwitchState<RogueIdleState>();
        }

        if (moveDir.x > 0)
        {
            player.ChangeLeft(false, false);
        }
        else if (moveDir.x < 0)
        {
            player.ChangeLeft(true, false);
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

    protected override void OnUpdate()
    {
        base.OnUpdate();
    }
}