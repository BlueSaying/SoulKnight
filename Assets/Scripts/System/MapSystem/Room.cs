using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Empty,
    Birth,
    Normal,
    Boss,
    Transmission,
    Speical,
    Chest,
    PathVer,
    PathHor,
}

public class Room
{
    public LevelType levelType;

    //private RoomType _roomType;
    public RoomType roomType;


    //public int height, width;
    public Vector2Int roomPos;
    public List<Vector2Int> pathConnection;

    public GameObject gameObject;

    public Room(LevelType levelType, RoomType roomType, Vector2Int roomPos)
    {
        this.levelType = levelType;
        this.roomType = roomType;
        this.roomPos = roomPos;
    }
}
