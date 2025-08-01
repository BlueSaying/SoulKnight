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

        if (!UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "Trigger"))
        {
            UnityTools.Instance.GetTransformFromChildren(obj, "Trigger").AddComponent<Symbol>();
        }
        UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "Trigger").SetCharacter(player);

        return player;
    }

    // 实例化一个玩家的游戏物体
    public GameObject InstantiatePlayer(PlayerType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject playerPrefab = ResourcesLoader.Instance.LoadPlayer(type.ToString());
        GameObject newPlayer = null;

        if (parent != null)
        {
            newPlayer = Object.Instantiate(playerPrefab, position, quaternion, parent);
        }
        else
        {
            newPlayer = Object.Instantiate(playerPrefab, position, quaternion);
        }

        newPlayer.name = type.ToString();
        return newPlayer;
    }
}