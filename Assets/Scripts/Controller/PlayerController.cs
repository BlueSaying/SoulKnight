public class PlayerController : AbstractController
{
    public IPlayer mainPlayer { get; protected set; }
    public PlayerController() { }
    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();

        if (mainPlayer != null)
        {
            mainPlayer.GameUpdate();
        }
    }

    public void SetMainPlayer(PlayerType playerType)
    {
        mainPlayer = PlayerFactory.Instance.GetPlayer(playerType);
        //mainPlayer.SetPlayerInput(GameMediator.Instance.GetController<InputController>().input);
    }
}