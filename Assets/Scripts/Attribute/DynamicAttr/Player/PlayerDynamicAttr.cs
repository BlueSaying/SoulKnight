public class PlayerDynamicAttr : CharacterDynamicAttr
{
    public PlayerSkinType playerSkinType;

    public int curArmor;

    public int curEnergy;

    public PlayerDynamicAttr()
    {
        curHP = 0;
        curArmor = 0;
        curEnergy = 0;
    }

    public PlayerDynamicAttr(int curHP, int curArmor, int curEnergy)
    {
        this.curHP = curHP;
        this.curArmor = curArmor;
        this.curEnergy = curEnergy;
    }
}