
public class RogueFSM : PlayerFSM
{
    public RogueFSM(Player player) : base(player)
    {
        SwitchState<RogueIdleState>();
    }
}