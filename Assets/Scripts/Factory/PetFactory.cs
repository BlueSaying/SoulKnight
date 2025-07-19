using UnityEngine;

public enum PetType
{
    LittleCool,

}

public class PetFactory : Singleton<PetFactory>
{
    private PetFactory() { }

    // 实例化一个宠物及其游戏物体
    public Pet CreatePet(PetType type, Player owner, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject newPet = InstantiatePet(type, position, quaternion, parent);
        Pet pet = null;

        switch (type)
        {
            case PetType.LittleCool:
                pet = new LittleCool(newPet, new PetStaticAttr(), owner);   // HACK
                break;
        }

        return pet;
    }

    // 实例化一个宠物的游戏物体
    public GameObject InstantiatePet(PetType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject petPrefab = ResourcesFactory.Instance.GetPet(type.ToString());
        GameObject newPet = null;

        if (parent != null)
        {
            newPet = Object.Instantiate(petPrefab, position, quaternion, parent);
        }
        else
        {
            newPet = Object.Instantiate(petPrefab, position, quaternion);
        }

        newPet.name = type.ToString();
        return newPet;
    }
}