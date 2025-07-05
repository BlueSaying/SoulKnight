using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerController : AbstractController
{
    public IPlayer mainPlayer {  get; protected set; }
    public PlayerController() { }
    protected override void OnInit()
    {
        base.OnInit();
        mainPlayer = PlayerFactory.Instance.GetPlayer(PlayerType.Knight);
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        mainPlayer.GameUpdate();
    }
}