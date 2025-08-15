using System.Collections.Generic;

public class PlayerRepository
{
    // 储存所有角色的数据
    private List<PlayerModel> models;

    public PlayerRepository()
    {
        List<PlayerStaticAttr> playerStaticData = SOLoader.GetPlayerSO().attrs;

        models = new List<PlayerModel>();
        for (int i = 0; i < playerStaticData.Count; i++)
        {
            models.Add(new PlayerModel(playerStaticData[i], /*HACK*/new PlayerDynamicAttr()));
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
}
