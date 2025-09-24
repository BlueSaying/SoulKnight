using UnityEngine;

public class PetFactory : Singleton<PetFactory>
{
    private PetFactory() { }

    // 实例化一个宠物及其游戏物体
    public Pet CreatePet(PetType type, Player owner, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        // HACK:目前不涉及数据
        GameObject newPet = InstantiatePet(type, position, quaternion, parent);
        Pet pet = null;

        switch (type)
        {
            case PetType.LittleCool:
                pet = new LittleCool(newPet, new PetModel(new PetStaticAttr(), new PetDynamicAttr()), owner);   // HACK
                break;
        }

        return pet;
    }

    // 实例化一个宠物的游戏物体
    public GameObject InstantiatePet(PetType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        if (parent == null) parent = GameObject.Find("Pets").transform;

        GameObject petPrefab = ResourcesLoader.Instance.LoadPet(type.ToString());
        GameObject newPet = null;

        newPet = Object.Instantiate(petPrefab, position, quaternion, parent);
        newPet.name = type.ToString();
        return newPet;
    }
}