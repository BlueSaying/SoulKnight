using Unity.VisualScripting;
using UnityEngine;

public class PlayerFactory : Singleton<PlayerFactory>
{
    private PlayerFactory() { }

    // NOTE:给定playerType，返回相应的IPlayer 每次创建新角色后都应该在此处书写
    public Player CreatePlayer(PlayerModel playerModel, Skill skill)
    {
        PlayerType playerType = playerModel.staticAttr.playerType;
        GameObject obj = GameObject.Find(playerType.ToString());
        Player player = null;

        switch (playerType)
        {
            case PlayerType.Knight:
                player = new Knight(obj, playerModel, skill);
                break;
            case PlayerType.Rogue:
                player = new Rogue(obj, playerModel, skill);
                break;
        }

        if (!UnityTools.GetComponentFromChildren<Symbol>(obj, "Trigger"))
        {
            UnityTools.GetTransformFromChildren(obj, "Trigger").AddComponent<Symbol>();
        }
        UnityTools.GetComponentFromChildren<Symbol>(obj, "Trigger").SetCharacter(player);

        return player;
    }

    // 实例化一个玩家的游戏物体
    public GameObject InstantiatePlayer(PlayerType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        if (parent == null) parent = GameObject.Find("Players").transform;

        GameObject playerPrefab = ResourcesLoader.Instance.LoadPlayer(type.ToString());
        GameObject newPlayer = null;

        newPlayer = Object.Instantiate(playerPrefab, position, quaternion, parent);
        newPlayer.name = type.ToString();
        return newPlayer;
    }
}