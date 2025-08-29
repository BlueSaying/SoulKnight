public class PlayerDynamicAttr : CharacterDynamicAttr
{
    public PlayerSkinType playerSkinType;

    public DynamicAttr<int> curArmor = new DynamicAttr<int>();

    public DynamicAttr<int> curEnergy = new DynamicAttr<int>();
}