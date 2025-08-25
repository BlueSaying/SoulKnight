using UnityEngine;

public static class DecorationFactory
{
    public static Chest InstantiateChest(Vector2 position, Quaternion quaternion)
    {
        GameObject chestPrefab = ResourcesLoader.Instance.LoadDecoration("Chest");
        return GameObject.Instantiate(chestPrefab, position, quaternion).GetComponent<Chest>();
    }
}