
using UnityEngine;

public class GoblinGuardStateMachine : EnemyStateMachine
{
    const float IdleTime = 3f;
    const float AttackDistance = 2f;

    private float timer = -1f;

    public GoblinGuardStateMachine(Enemy enemy) : base(enemy)
    {
        SwitchState<EnemyIdleState>();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (curState is EnemyIdleState)
        {
            if (timer <= -1f)
            {
                timer = UnityTools.Instance.GetRandomFloat(0.8f * IdleTime, 1.25f * IdleTime);
            }
            else if (timer <= 0f)
            {
                SwitchState<EnemyRunState>();
                timer = -1;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (curState is EnemyRunState)
        {
            if (DistanceToTargetPlayer() < AttackDistance * AttackDistance)
            {
                SwitchState<EnemyAttackState>();
            }
        }

        if (curState is EnemyAttackState)
        {
            if (DistanceToTargetPlayer() > AttackDistance * AttackDistance * 2.25f)
            {
                SwitchState<EnemyIdleState>();
            }
        }
    }

    private float DistanceToTargetPlayer()
    {
        float x = (targetPlayer.transform.position.x - enemy.transform.position.x);
        float y = (targetPlayer.transform.position.y - enemy.transform.position.y);
        return x * x + y * y;
    }
}