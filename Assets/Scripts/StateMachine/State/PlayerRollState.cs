public class PlayerRollState : IPlayerState
{
    public PlayerRollState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    
    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetTrigger("isRoll");
    }
}