using System.Collections.Generic;

public class PlayerRepository
{
    // 储存所有角色的数据
    private List<PlayerModel> models;

    public PlayerRepository()
    {
        List<PlayerStaticAttr> playerStaticData = SOLoader.Instance.LoadScriptableObject<PlayerSO>().attrs;

        models = new List<PlayerModel>();
        for (int i = 0; i < playerStaticData.Count; i++)
        {
            models.Add(new PlayerModel(playerStaticData[i], new PlayerDynamicAttr()));
        }
    }

    public PlayerModel GetPlayerModel(PlayerType playerType)
    {
        foreach (var model in models)
        {
            if (model.staticAttr.playerType == playerType)
            {
                return model;
            }
        }

        return default;
    }

    // 获取特定玩家类型的属性
    //public PlayerStaticAttr GetPlayerStaticAttr(PlayerType playerType)
    //{
    //    foreach (var attr in playerStaticData)
    //    {
    //        if (attr.playerType == playerType)
    //        {
    //            return attr;
    //        }
    //    }
    //
    //    return default;
    //}
}
