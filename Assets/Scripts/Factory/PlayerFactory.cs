using Unity.VisualScripting;
using UnityEngine;

public enum PlayerType
{
    Knight,
    Rogue,
}

public enum PlayerSkinType
{
    Knight,
    Rogue,
    RogueKun,
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

    // NOTE:给定playerType，返回相应的IPlayer 每次创建新角色后都应该在此处书写
    public IPlayer GetPlayer(PlayerType playerType)
    {
        GameObject obj = GameObject.Find(playerType.ToString());
        IPlayer player = null;

        switch (playerType)
        {
            case PlayerType.Knight:
                player = new Knight(obj);
                break;
            case PlayerType.Rogue:
                player = new Rogue(obj);
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