public class RogueRollState : IPlayerState
{
    public RogueRollState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    // TODO:implement this state
    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetTrigger("isRoll");
    }
}