using UnityEngine;

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

    //public void SetMainPlayerSkin(PlayerSkinType skinType)
    //{
    //    if (mainPlayer == null) throw new System.Exception("无角色，无法设置皮肤");
    //
    //    //implement this function
    //    //mainPlayer
    //}
}