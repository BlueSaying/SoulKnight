
public class PlayerStateMachine : BaseStateMachine
{
    public IPlayer player { get;protected set; }
    public PlayerStateMachine(IPlayer player):base()
    {
        this.player = player;
    }
}