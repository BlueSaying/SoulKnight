
public class DynamicAttrFactory : Singleton<DynamicAttrFactory>
{
    private DynamicAttrFactory() { }

    //public PlayerStaticAttr GetPlayerDynamicAttr(PlayerType playerType)
    //{
    //    return new PlayerDynamicAttr(PlayerCommand.Instance.GetPlayerStaticAttr(playerType));
    //}

    public PetStaticAttr GetPetStaticAttr(PetType petType)
    {
        return null;
    }
}