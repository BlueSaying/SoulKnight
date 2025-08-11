using UnityEngine;

public class GoblinGuardState : EnemyState
{
    protected const float AttackDistance = 2f;
    protected const float IdleTime = 2f;

    public GoblinGuardState(FSM fsm) : base(fsm) { }
}

public class GoblinGuardIdleState : GoblinGuardState
{
    private float timer;

    public GoblinGuardIdleState(FSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        rb.velocity = Vector2.zero;
        timer = -1f;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (timer <= -1f)
        {
            timer = UnityTools.GetRandomFloat(0.8f * IdleTime, 1.25f * IdleTime);
        }
        else if (timer <= 0f)
        {
            fsm.SwitchState<GoblinGuardRunState>();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

public class GoblinGuardRunState : GoblinGuardState
{
    public GoblinGuardRunState(FSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isRun", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        rb.velocity = (targetPlayer.transform.position - enemy.transform.position).normalized * enemy.model.staticAttr.speed;

        if (enemy.DistanceToTargetPlayer() < AttackDistance * AttackDistance)
        {
            fsm.SwitchState<GoblinGuardAttackState>();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isRun", false);
    }
}

public class GoblinGuardAttackState : GoblinGuardState
{
    public GoblinGuardAttackState(FSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isAttack", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Attack");

        if (enemy.DistanceToTargetPlayer() > AttackDistance * AttackDistance * 2.25f)
        {
            fsm.SwitchState<GoblinGuardIdleState>();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isAttack", false);
    }
}