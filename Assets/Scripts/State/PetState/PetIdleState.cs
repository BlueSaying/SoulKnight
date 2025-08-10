using UnityEngine;

public class PetIdleState : PetState
{
    public PetIdleState(StateMachine stateMachine) : base(stateMachine) { }


    protected override void OnEnter()
    {
        base.OnEnter();
        rb.velocity = Vector2.zero;
        animator.SetBool("isIdle", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isIdle", false);
    }
}
