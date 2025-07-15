using UnityEditor.U2D.Aseprite;
using UnityEngine;

public enum PetType
{
    LittleCool,

}

public class PetFactory : Singleton<PetFactory>
{
    private PetFactory() { }

    public BasePet GetPet(PetType type, IPlayer owner)
    {
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