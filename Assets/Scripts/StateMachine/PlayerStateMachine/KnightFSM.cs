
public class KnightFSM : PlayerFSM
{
    public KnightFSM(Player player) : base(player)
    {
        SwitchState<KnightIdleState>();
    }
}