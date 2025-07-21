using System;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerType
{
    Knight,
    Rogue,
}

public enum PlayerSkinType
{
    None,
    Knight,
    Rogue,
    RogueKun,
}

public class PlayerFactory : Singleton<PlayerFactory>
{
    private PlayerFactory() { }

    // NOTE:给定playerType，返回相应的IPlayer 每次创建新角色后都应该在此处书写
    public Player CreatePlayer(PlayerModel playerModel)
    {
        PlayerType playerType = playerModel.staticAttr.playerType;
        GameObject obj = GameObject.Find(playerType.ToString());
        Player player = null;

        switch (playerType)
        {
            case PlayerType.Knight:
                player = new Knight(obj, playerModel);
                break;
            case PlayerType.Rogue:
                player = new Rogue(obj, playerModel);
                break;
        }

        if (!UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox"))
        {
            UnityTools.Instance.GetTransformFromChildren(obj, "BulletCheckBox").AddComponent<Symbol>();
        }
        UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(player);

        return player;
    }
}