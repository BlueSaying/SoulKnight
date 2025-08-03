
public class EnemyRunState : EnemyState
{
    public EnemyRunState(StateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isRun", true);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        rb.velocity = (targetPlayer.transform.position - enemy.transform.position).normalized * enemy.model.staticAttr.speed;
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isRun", false);
    }
}