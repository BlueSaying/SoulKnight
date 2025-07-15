public class PlayerRollState : PlayerState
{
    public PlayerRollState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    
    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetTrigger("isRoll");
    }
}