using System.Collections.Generic;

public class PlayerCommand : Singleton<PlayerCommand>
{
    private PlayerModel playerModel;
    private PlayerSkinModel playerSkinModel;

    private PlayerCommand()
    {
        playerModel = ModelContainer.Instance.GetModel<PlayerModel>();
        playerSkinModel = ModelContainer.Instance.GetModel<PlayerSkinModel>();
    }

    // 获取特定玩家类型的属性
    public PlayerStaticAttr GetPlayerStaticAttr(PlayerType playerType)
    {
        foreach (var attr in playerModel.datas)
        {
            if (attr.playerType == playerType)
            {
                return attr;
            }
        }

        return default;
    }

    // 获取特定角色类型的所有皮肤
    public List<PlayerSkinType> GetPlayerSkinStaticTypes(PlayerType playerType)
    {
        foreach(var playerSkin in playerSkinModel.datas)
        {
            if(playerSkin.playerType == playerType)
            {
                return playerSkin.playerSkinTypes;
            }
        }

        return default;
    }
}