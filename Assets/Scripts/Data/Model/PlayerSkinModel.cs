using System.Collections.Generic;

public class PlayerSkinModel : AbstractModel
{
    public PlayerSkinStaticAttr staticAttr;

    public PlayerSkinModel(PlayerSkinStaticAttr staticAttr)
    {
        this.staticAttr = staticAttr;
    }
}