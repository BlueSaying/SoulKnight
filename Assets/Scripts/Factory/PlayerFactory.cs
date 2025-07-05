using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Build.Player;
using UnityEngine;

public enum PlayerType
{
    Knight,
}

public class PlayerFactory
{
    private static PlayerFactory _instance;
    public static PlayerFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerFactory();
            }
            return _instance;
        }
    }

    private PlayerFactory() { }

    public IPlayer GetPlayer(PlayerType playerType)
    {
        GameObject obj = GameObject.Find(playerType.ToString());
        IPlayer player = null;

        switch (playerType)
        {
            case PlayerType.Knight:
                player = new Knight(obj);
                break;

        }

        return player;
    }
}