using UnityEngine;

public static class DecorationFactory
{
    public static Chest InstantiateChest(Vector2 position, Quaternion quaternion)
    {
        GameObject chestPrefab = ResourcesLoader.Instance.LoadDecoration("Chest");

        GameObject chest = GameObject.Instantiate(chestPrefab, position, quaternion);
        chest.name = chest.name.Replace("(Clone)", "");

        return chest.GetComponent<Chest>();
    }
}