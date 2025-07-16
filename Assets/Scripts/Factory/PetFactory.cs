using UnityEditor.U2D.Aseprite;
using UnityEngine;

public enum PetType
{
    LittleCool,

}

public class PetFactory : Singleton<PetFactory>
{
    private PetFactory() { }

    public Pet GetPet(PetType type, Player owner)
    {
        // TOD:modify it later
        GameObject obj = GameObject.Find(type.ToString());
        Pet pet = null;

        switch (type)
        {
            case PetType.LittleCool:
                pet = new LittleCool(obj, new PetStaticAttr(),owner);   // HACK
                break;
        }

        return pet;
    }
}