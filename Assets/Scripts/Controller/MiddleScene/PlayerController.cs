using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : AbstractController
{
    public IPlayer mainPlayer {  get; protected set; }
    public PlayerController() { }
    protected override void OnInit()
    {
        base.OnInit();

        // NOTE:初始化一个骑士
        //mainPlayer = PlayerFactory.Instance.GetPlayer(PlayerType.Knight);
        //mainPlayer.SetPlayerInput(GameMediator.Instance.GetController<InputController>().input);
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        //mainPlayer.GameUpdate();

    }
}