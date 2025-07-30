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

    public RoomType roomType;

    //public int height, width;
    public Vector2Int roomPos;
    public List<Vector2Int> pathConnection;

    public GameObject gameObject;

    public Room(LevelType levelType, RoomType roomType, Vector2Int roomPos,GameObject gameObject)
    {
        this.levelType = levelType;
        this.roomType = roomType;
        this.roomPos = roomPos;
        this.gameObject = gameObject;
        pathConnection = new List<Vector2Int>();
    }

    public virtual void OnPlayerEnter(GameObject obj)
    {
        if (!obj.CompareTag("Player")) return;
    }

    protected virtual void OpenDoor()
    {
        Transform doors = gameObject.transform.Find("Doors");
        foreach(var dir in pathConnection)
        {
            if(dir ==Vector2Int.up) doors.Find("Up").gameObject.SetActive(true);
            if(dir ==Vector2Int.down) doors.Find("Down").gameObject.SetActive(true);
            if(dir ==Vector2Int.left) doors.Find("Left").gameObject.SetActive(true);
            if(dir ==Vector2Int.right) doors.Find("Right").gameObject.SetActive(true);
        }
    }

    protected virtual void CloseDoor()
    {
        Transform doors = gameObject.transform.Find("Doors");
        foreach (var dir in pathConnection)
        {
            if (dir == Vector2Int.up) doors.Find("Up").gameObject.SetActive(false);
            if (dir == Vector2Int.down) doors.Find("Down").gameObject.SetActive(false);
            if (dir == Vector2Int.left) doors.Find("Left").gameObject.SetActive(false);
            if (dir == Vector2Int.right) doors.Find("Right").gameObject.SetActive(false);
        }
    }
}
