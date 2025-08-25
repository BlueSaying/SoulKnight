using UnityEngine;

public class ChestRoom : Room
{
    public ChestRoom(LevelType levelType, RoomType roomType, BoundsInt bounds, GameObject gameObject)
        : base(levelType, roomType, bounds, gameObject) { }

}