using System.Collections.Generic;

public class PlayerModel:AbstractModel
{
    public List<PlayerShareAttr> data;

    protected override void OnInit()
    {
        base.OnInit();
        data = ResourcesFactory.Instance.GetScriptableObject<PlayerScriptableObject>().playershareAttrs;
    }

    public PlayerShareAttr GetPlayerShareAttr(PlayerType type)
    {
        foreach (var attr in data)
        {
            if(attr.playerType == type)
            {
                return attr;
            }
        }

        return default;
    }
}