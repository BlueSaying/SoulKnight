using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public LevelType levelType;

    public RoomType roomType;

    public BoundsInt bounds;
    public List<Vector2Int> corridors;

    public GameObject gameObject;

    public Room(LevelType levelType, RoomType roomType, BoundsInt bounds, GameObject gameObject)
    {
        this.levelType = levelType;
        this.roomType = roomType;
        this.bounds = bounds;
        this.gameObject = gameObject;
        corridors = new List<Vector2Int>();
    }

    public virtual void OnPlayerEnter(GameObject obj)
    {
        //if (!obj.CompareTag("Player")) return;
    }

    protected virtual void OpenDoor()
    {
        Transform doors = gameObject.transform.Find("Room").Find("Doors");
        foreach (var dir in corridors)
        {
            if (dir == Vector2Int.up) doors.Find("Up").gameObject.SetActive(false);
            if (dir == Vector2Int.down) doors.Find("Down").gameObject.SetActive(false);
            if (dir == Vector2Int.left) doors.Find("Left").gameObject.SetActive(false);
            if (dir == Vector2Int.right) doors.Find("Right").gameObject.SetActive(false);
        }
    }

    protected virtual void CloseDoor()
    {
        Transform doors = gameObject.transform.Find("Room").Find("Doors");
        foreach (var dir in corridors)
        {
            if (dir == Vector2Int.up) doors.Find("Up").gameObject.SetActive(true);
            if (dir == Vector2Int.down) doors.Find("Down").gameObject.SetActive(true);
            if (dir == Vector2Int.left) doors.Find("Left").gameObject.SetActive(true);
            if (dir == Vector2Int.right) doors.Find("Right").gameObject.SetActive(true);
        }
    }
}
