
public class PlayerFSM : FSM
{
    public Player player { get; protected set; }

    public PlayerFSM(Player player) : base()
    {
        this.player = player;
    }
}