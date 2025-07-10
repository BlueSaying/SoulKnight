public class PlayerController : AbstractController
{
    public IPlayer mainPlayer { get; protected set; }
    public PlayerController() { }
    protected override void OnInit()
    {
        base.OnInit();

        // NOTE:初始化一个骑士
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
        mainPlayer.SetPlayerInput(GameMediator.Instance.GetController<InputController>().input);
    }
}