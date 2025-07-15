
public class AttributeFactory : Singleton<AttributeFactory>
{
    private AttributeFactory() { }

    //public PlayerDynamicAttr GetPlayerDynamicAttr(PlayerType playerType)
    //{
    //    return new PlayerDynamicAttr(PlayerCommand.Instance.GetPlayerStaticAttr(playerType));
    //}

    public PetStaticAttr GetPetStaticAttr(PetType petType)
    {
        return null;
    }
}