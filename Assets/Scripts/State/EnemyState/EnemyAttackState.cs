
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(StateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isAttack", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Attack");
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isAttack", false);
    }
}