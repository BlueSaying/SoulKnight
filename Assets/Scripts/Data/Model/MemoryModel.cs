
using System.Collections.Generic;

public class MemoryModel:AbstractModel
{
    public PlayerStaticAttr playerStaticAttr;
    public PlayerDynamicAttr playerDynamicAttr;
    public List<PlayerWeaponType> weapons;
    public List<PetType> pets;
    public string userName;
    public int stage=5;
    public int gold=0;
}