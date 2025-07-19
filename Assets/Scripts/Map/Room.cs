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

    private RoomType _roomType;
    public RoomType roomType
    {
        get
        {
            return _roomType;
        }
        set
        {
            _roomType = value;

            if (_roomType != RoomType.Empty)
            {
                gameObject = ResourcesFactory.Instance.GetLevelRoom(levelType.ToString(), _roomType.ToString());
            }
            else gameObject = null;
        }
    }

    //public int height, width;
    public Vector2Int roomPos;
    public List<Vector2Int> pathConnection;

    public GameObject gameObject;


    public Room(LevelType levelType, RoomType roomType, Vector2Int roomPos)
    {
        pathConnection = new List<Vector2Int>();
        this.levelType = levelType;
        this.roomType = roomType;
        this.roomPos = roomPos;
    }
}
