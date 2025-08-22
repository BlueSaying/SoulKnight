using UnityEngine;

public class GoblinGuardState : EnemyState
{
    protected const float AttackDistance = 2f;
    protected const float IdleTime = 2f;

    public GoblinGuardState(FSM fsm) : base(fsm) { }

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector2 dir = targetPlayer.transform.position - enemy.transform.position;
        if (dir.x > 0f)
        {
            enemy.ChangeLeft(false, false);
        }
        else
        {
            enemy.ChangeLeft(true, false);
        }
    }
}

public class GoblinGuardIdleState : GoblinGuardState
{
    private float timer;

    public GoblinGuardIdleState(FSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        timer = -1f;
    }

    public override void OnUpdate()
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

    public override void OnUpdate()
    {
        base.OnUpdate();
        Vector2 dir = (targetPlayer.transform.position - enemy.transform.position).normalized;
        rb.velocity = dir * enemy.model.staticAttr.speed;

        if (enemy.DistanceToTargetPlayer() < AttackDistance * AttackDistance)
        {
            fsm.SwitchState<GoblinGuardAttackState>();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        rb.velocity = Vector2.zero;
        animator.SetBool("isRun", false);
    }
}

public class GoblinGuardAttackState : GoblinGuardState
{
    public GoblinGuardAttackState(FSM fsm) : base(fsm) { }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if(enemy.weapon!=null)
        {
            enemy.weapon.OnFixedUpdate();
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (enemy.DistanceToTargetPlayer() > AttackDistance * AttackDistance * 2.25f)
        {
            fsm.SwitchState<GoblinGuardIdleState>();
        }

        Vector2 dir = (targetPlayer.transform.position - enemy.transform.position).normalized;
        if (enemy.weapon != null)
        {
            enemy.weapon.OnUpdate();
            enemy.weapon.ControlWeapon(true);
            enemy.weapon.RotateWeapon(targetPlayer.transform.position - enemy.transform.position);
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        if (enemy.weapon != null)
        {
            enemy.weapon.RotateWeapon(Vector2.right);
        }
    }
}