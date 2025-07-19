using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    Forest,
}

public class RoomCreator : MonoBehaviour
{
    private static readonly int RoomSize = 5;
    private static readonly int UnitSize = 35;
    private static readonly Vector2Int[] Dir = { Vector2Int.down, Vector2Int.left, Vector2Int.right, Vector2Int.up };

    private static readonly Vector2Int birthPos = new Vector2Int(2, 2);

    private LevelType curLevel;

    private Room[,] roomMatrix = new Room[RoomSize, RoomSize];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CreateLevel(LevelType.Forest);
        }
    }

    private void Refresh()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < RoomSize; i++)
        {
            for (int j = 0; j < RoomSize; j++)
            {
                roomMatrix[i, j] = new Room(curLevel, RoomType.Empty, Vector2Int.zero);
            }
        }
    }

    private void OpenDoor(Room room1, Room room2)
    {
        Vector2Int pos1 = room1.roomPos;
        Vector2Int pos2 = room2.roomPos;
        Transform grad1 = room1.gameObject.transform.Find("Grid");
        Transform grad2 = room2.gameObject.transform.Find("Grid");

        if (Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y) > 1) return;

        if (pos1.x == pos2.x)
        {
            if (pos1.y > pos2.y)
            {
                grad1.Find("WallDoorDown").gameObject.SetActive(false);
                grad2.Find("WallDoorUp").gameObject.SetActive(false);
            }
            else
            {
                grad1.Find("WallDoorUp").gameObject.SetActive(false);
                grad2.Find("WallDoorDown").gameObject.SetActive(false);
            }
        }
        else
        {
            if (pos1.x > pos2.x)
            {
                grad1.Find("WallDoorLeft").gameObject.SetActive(false);
                grad2.Find("WallDoorRight").gameObject.SetActive(false);
            }
            else
            {
                grad1.Find("WallDoorRight").gameObject.SetActive(false);
                grad2.Find("WallDoorLeft").gameObject.SetActive(false);
            }
        }

        
    }

    private GameObject InstantiatePath(Room room1, Room room2)
    {
        Vector2Int pos1 = room1.roomPos;
        Vector2Int pos2 = room2.roomPos;

        if (Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y) > 1) return null;

        Vector2Int leftDwonPos, rightUpPos;
        if (pos1.x < pos2.x) { leftDwonPos = pos1; rightUpPos = pos2; }
        else if (pos1.x > pos2.x) { leftDwonPos = pos2; rightUpPos = pos1; }
        else if (pos1.y < pos2.y) { leftDwonPos = pos1; rightUpPos = pos2; }
        else { leftDwonPos = pos2; rightUpPos = pos1; }

        GameObject pathPrefab;
        if (leftDwonPos.x == rightUpPos.x) pathPrefab = ResourcesFactory.Instance.GetLevelRoom(curLevel.ToString(), RoomType.PathVer.ToString());
        else pathPrefab = ResourcesFactory.Instance.GetLevelRoom(curLevel.ToString(), RoomType.PathHor.ToString());

        Vector2 pathPos = leftDwonPos * UnitSize;
        return Instantiate(pathPrefab, pathPos, Quaternion.identity, transform);
    }

    private GameObject InstantiateRoom(Room room)
    {
        GameObject roomPrefab = ResourcesFactory.Instance.GetLevelRoom(curLevel.ToString(), room.roomType.ToString());
        return Instantiate(roomPrefab, (Vector2)room.roomPos * UnitSize, Quaternion.identity, transform);
    }

    private void AddPath(Room room1, Room room2)
    {
        Vector2Int pos1 = room1.roomPos;
        Vector2Int pos2 = room2.roomPos;

        if (Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y) != 1) return;

        if (pos1.x == pos2.x)
        {
            if (pos1.y > pos2.y)
            {
                room1.pathConnection.Add(Vector2Int.down);
                room2.pathConnection.Add(Vector2Int.up);
            }
            else
            {
                room1.pathConnection.Add(Vector2Int.up);
                room2.pathConnection.Add(Vector2Int.down);
            }
        }
        else
        {
            if (pos1.x > pos2.x)
            {
                room1.pathConnection.Add(Vector2Int.left);
                room2.pathConnection.Add(Vector2Int.right);
            }
            else
            {
                room1.pathConnection.Add(Vector2Int.right);
                room2.pathConnection.Add(Vector2Int.left);
            }
        }
    }

    private bool IsOutofMap(Vector2Int pos)
    {
        return pos.x < 0 || pos.y < 0 || pos.x >= RoomSize || pos.y >= RoomSize;
    }

    private float PDF(float x)
    {
        return Mathf.Exp(-x);
    }

    private Vector2Int GetExtendablePos()
    {
        List<Vector2Int> extendablePos = new List<Vector2Int>();
        int[,] distance = new int[RoomSize, RoomSize];

        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(birthPos);
        bool[,] visited = new bool[RoomSize, RoomSize];
        for (int i = 0; i < RoomSize; i++)
            for (int j = 0; j < RoomSize; j++)
            {
                distance[i, j] = 0;
                visited[i, j] = false;
            }
        Vector2Int curPos = birthPos;

        while (queue.Count > 0)
        {
            Vector2Int roomPos = queue.Dequeue();
            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].pathConnection)
            {
                Vector2Int newPos = roomPos + path;
                if (visited[newPos.x, newPos.y]) continue;

                // do something for roomPos here
                // empty implement now
                distance[newPos.x, newPos.y] = distance[roomPos.x, roomPos.y] + 1;
                queue.Enqueue(newPos);
            }

            visited[roomPos.x, roomPos.y] = true;

            bool flag = false;
            foreach (var path in Dir)
            {
                if (roomMatrix[roomPos.x, roomPos.y].pathConnection.Contains(path)) continue;

                Vector2Int newPos = roomPos + path;
                if (IsGeneratable(newPos)) flag = true;
            }
            if (flag && roomPos != birthPos) extendablePos.Add(roomPos);
        }

        float distanceTotal = 0f;
        for (int i = 0; i < extendablePos.Count; i++)
        {
            distanceTotal += PDF(distance[extendablePos[i].x, extendablePos[i].y]);
        }

        int index = 0;
        float distanceCount = 0f;
        float targetDis = UnityTools.Instance.GetRandomFloat(0f, distanceTotal);
        for (int i = 0; i < extendablePos.Count; i++)
        {
            distanceCount += PDF(distance[extendablePos[i].x, extendablePos[i].y]);
            if (distanceCount > targetDis)
            {
                index = i;
                break;
            }
        }

        return extendablePos[index];
    }

    private bool IsGeneratable(Vector2Int pos)
    {
        if (IsOutofMap(pos)) return false;

        if (roomMatrix[pos.x, pos.y].roomType != RoomType.Empty) return false;

        return true;
    }

    private Vector2Int GetGeneratable(Vector2Int roomPos)
    {
        for (int i = 0; i < 1000000; i++)
        {
            Vector2Int newPos = roomPos + Dir[UnityTools.Instance.GetRandomInt(0, 3)];

            if (!IsGeneratable(newPos)) continue;

            return newPos;
        }

        return roomPos;
    }

    public void CreateLevel(LevelType levelType)
    {
        curLevel = levelType;
        Refresh();

        // 普通关卡生成5-7个房间
        int curRoomCount = 0;
        int roomCount = UnityTools.Instance.GetRandomInt(5, 7);

        // 构建大本营
        Vector2Int curPos = birthPos;

        roomMatrix[curPos.x, curPos.y] = new Room(curLevel, RoomType.Birth, curPos);
        curRoomCount++;

        // 构建第一个房间
        // 生成路径
        curPos = birthPos + Dir[UnityTools.Instance.GetRandomInt(0, 3)];

        //生成房间
        roomMatrix[curPos.x, curPos.y] = new Room(curLevel, RoomType.Normal, curPos);
        AddPath(roomMatrix[curPos.x, curPos.y], roomMatrix[birthPos.x, birthPos.y]);
        curRoomCount++;

        // 构建所有Normal房间
        while (curRoomCount < roomCount)
        {
            Vector2Int extendablePos = GetExtendablePos();
            curPos = GetGeneratable(extendablePos);// 从周围四个方向找一个generatable的

            // 生成房间
            if (curRoomCount == roomCount - 1)
            {
                roomMatrix[curPos.x, curPos.y] = new Room(curLevel, RoomType.Transmission, curPos);
            }
            else
            {

                roomMatrix[curPos.x, curPos.y] = new Room(curLevel, RoomType.Normal, curPos);
            }

            AddPath(roomMatrix[curPos.x, curPos.y], roomMatrix[extendablePos.x, extendablePos.y]);
            curRoomCount++;
        }

        InstantiateLevel();

        Debug.Log(roomCount + "个房间");
    }

    private void InstantiateLevel()
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(birthPos);
        bool[,] visited = new bool[RoomSize, RoomSize];
        for (int i = 0; i < RoomSize; i++)
            for (int j = 0; j < RoomSize; j++)
                visited[i, j] = false;
        Vector2Int curPos = birthPos;

        while (queue.Count > 0)
        {
            Vector2Int roomPos = queue.Dequeue();

            roomMatrix[roomPos.x,roomPos.y].gameObject = InstantiateRoom(roomMatrix[roomPos.x, roomPos.y]);
            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].pathConnection)
            {
                Vector2Int newPos = roomPos + path;
                if (visited[newPos.x, newPos.y]) continue;

                InstantiatePath(roomMatrix[roomPos.x, roomPos.y], roomMatrix[newPos.x, newPos.y]);
                queue.Enqueue(newPos);
            }

            visited[roomPos.x, roomPos.y] = true;
        }

        OpenAllDoor();
    }

    private void OpenAllDoor()
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(birthPos);
        bool[,] visited = new bool[RoomSize, RoomSize];
        for (int i = 0; i < RoomSize; i++)
            for (int j = 0; j < RoomSize; j++)
                visited[i, j] = false;
        Vector2Int curPos = birthPos;

        while (queue.Count > 0)
        {
            Vector2Int roomPos = queue.Dequeue();

            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].pathConnection)
            {
                Vector2Int newPos = roomPos + path;
                if (visited[newPos.x, newPos.y]) continue;

                OpenDoor(roomMatrix[roomPos.x, roomPos.y], roomMatrix[newPos.x, newPos.y]);
                queue.Enqueue(newPos);
            }

            visited[roomPos.x, roomPos.y] = true;
        }
    }
}