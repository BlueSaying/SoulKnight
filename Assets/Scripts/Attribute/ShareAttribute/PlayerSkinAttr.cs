using System;
using System.Collections.Generic;

[Serializable]
public class PlayerSkinAttr
{
    // 所指角色类型
    public PlayerType playerType;

    // *playerType*所有的皮肤
    public List<PlayerSkinType> playerSkinType;
}