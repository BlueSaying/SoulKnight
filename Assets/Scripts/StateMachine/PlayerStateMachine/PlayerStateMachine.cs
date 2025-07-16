
public class PlayerStateMachine : StateMachine
{
    public Player player { get;protected set; }
    public PlayerStateMachine(Player player):base()
    {
        this.player = player;
    }
}