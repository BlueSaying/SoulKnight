
public class PlayerStateMachine : BaseStateMachine
{
    public Player player { get;protected set; }
    public PlayerStateMachine(Player player):base()
    {
        this.player = player;
    }
}