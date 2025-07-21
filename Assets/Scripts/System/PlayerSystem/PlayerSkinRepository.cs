using System.Collections.Generic;

public class PlayerSkinRepository
{
    // 储存所有角色皮肤的模型
    private List<PlayerSkinModel> models;

    public PlayerSkinRepository()
    {
        List<PlayerSkinStaticAttr> playerSkinStaticData = SOLoader.Instance.LoadScriptableObject<PlayerSkinSO>().attrs;

        models = new List<PlayerSkinModel>();
        for (int i = 0; i < playerSkinStaticData.Count; i++)
        {
            models.Add(new PlayerSkinModel(playerSkinStaticData[i]));
            
        }
    }

    // 获取特定角色类型的所有皮肤
    public PlayerSkinModel GetPlayerSkinModel(PlayerType playerType)
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