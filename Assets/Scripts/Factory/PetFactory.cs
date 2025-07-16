using UnityEditor.U2D.Aseprite;
using UnityEngine;

public enum PetType
{
    LittleCool,

}

public class PetFactory : Singleton<PetFactory>
{
    private PetFactory() { }

    public BasePet GetPet(PetType type, Player owner)
    {
        // TOD:modify it later
        GameObject obj = GameObject.Find(type.ToString());
        BasePet pet = null;

        switch (type)
        {
            case PetType.LittleCool:
                pet = new LittleCool(obj, owner);
                break;
        }

        return pet;
    }
}