public class RogueRollState : IPlayerState
{
    public RogueRollState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetBool("isIdle", true);
    }
}