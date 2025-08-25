using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSystem : BaseSystem
{
    public static readonly int RoomSize = 5;
    public static readonly int UnitSize = 35;
    public static readonly Vector2Int[] Dir = { Vector2Int.down, Vector2Int.left, Vector2Int.right, Vector2Int.up };

    public static readonly Vector2Int birthPos = new Vector2Int(2, 2);

    private LevelRepository levelRepository;
    private LevelType curLevel;

    public Room[,] roomMatrix = new Room[RoomSize, RoomSize];

    // rooms的父物体
    private Transform roomParent;
    public Transform RoomParent
    {
        get
        {
            if (roomParent == null) roomParent = GameObject.Find("Rooms").transform;
            if (roomParent == null) throw new System.Exception("无法找到游戏物体Rooms，请添加");
            return roomParent;
        }
    }

    public MapSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        levelRepository = new LevelRepository();
    }

    private void Refresh()
    {
        for (int i = 0; i < RoomParent.childCount; i++)
        {
            Object.Destroy(RoomParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < RoomSize; i++)
        {
            for (int j = 0; j < RoomSize; j++)
            {
                roomMatrix[i, j] = new Room(curLevel, RoomType.Empty, new BoundsInt(), null);
            }
        }
    }

    private void OpenDoor(Room room1, Room room2)
    {
        Vector2Int pos1 = (Vector2Int)room1.bounds.position;
        Vector2Int pos2 = (Vector2Int)room2.bounds.position;
        Transform grad1 = room1.gameObject.transform.Find("Grid");
        Transform grad2 = room2.gameObject.transform.Find("Grid");

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

    private GameObject InstantiateCorridors(Room room1, Room room2)
    {
        BoundsInt bounds1 = room1.bounds;
        BoundsInt bounds2 = room2.bounds;
        Vector2Int pos1 = (Vector2Int)bounds1.position;
        Vector2Int pos2 = (Vector2Int)bounds2.position;

        BoundsInt leftDwonBounds, rightUpBounds;
        if (pos1.x < pos2.x) { leftDwonBounds = bounds1; rightUpBounds = bounds2; }
        else if (pos1.x > pos2.x) { leftDwonBounds = bounds2; rightUpBounds = bounds1; }
        else if (pos1.y < pos2.y) { leftDwonBounds = bounds1; rightUpBounds = bounds2; }
        else { leftDwonBounds = bounds2; rightUpBounds = bounds1; }

        GameObject corridorPrefab = ResourcesLoader.Instance.LoadLevelRoom(curLevel.ToString(), RoomType.Corridor.ToString());
        GameObject newCorridor = Object.Instantiate(corridorPrefab, Vector3.zero, Quaternion.identity, RoomParent);

        // paint tile
        TileBase floorTile, wallTile;
        floorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.corridorStaticAttr.floorTile;
        wallTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.corridorStaticAttr.wallTile;
        BoundsInt corridorBounds;
        if (pos1.y == pos2.y)
        {
            corridorBounds = new BoundsInt
            (new Vector3Int(leftDwonBounds.xMax + 1, leftDwonBounds.yMin + leftDwonBounds.size.y / 2 - 2),
            new Vector3Int(rightUpBounds.xMin - leftDwonBounds.xMax - 2, 5));
        }
        else
        {
            corridorBounds = new BoundsInt
            (new Vector3Int(leftDwonBounds.xMin + leftDwonBounds.size.x / 2 - 2, leftDwonBounds.yMax + 1),
            new Vector3Int(5, rightUpBounds.yMin - leftDwonBounds.yMax - 2));
        }
        PaintSingleCorridor(newCorridor, corridorBounds, floorTile, wallTile);


        return newCorridor;
    }

    private GameObject InstantiateRooms(RoomType roomType, BoundsInt roomBounds)
    {
        GameObject roomPrefab = ResourcesLoader.Instance.LoadLevelRoom(curLevel.ToString(), roomType.ToString());
        GameObject newRoom = Object.Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, RoomParent);

        // HACK
        newRoom.transform.Find("Room").position = roomBounds.center;

        // paint tile
        TileBase floorTile, wallTile, doorTile;
        switch (roomType)
        {
            case RoomType.Birth:
                floorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.birthRoomStaticAttr.floorTile;
                wallTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.birthRoomStaticAttr.wallTile;
                doorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.birthRoomStaticAttr.doorTile;

                PaintSingleRoom(newRoom, roomBounds, floorTile, wallTile, doorTile);
                break;

            case RoomType.Normal:
                floorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.normalRoomStaticAttr.floorTile;
                wallTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.normalRoomStaticAttr.wallTile;
                doorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.normalRoomStaticAttr.doorTile;

                PaintSingleRoom(newRoom, roomBounds, floorTile, wallTile, doorTile);
                break;

            case RoomType.Boss:
                break;

            case RoomType.Transmission:
                floorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.transmissionRoomStaticAttr.floorTile;
                wallTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.transmissionRoomStaticAttr.wallTile;
                doorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.transmissionRoomStaticAttr.doorTile;

                PaintSingleRoom(newRoom, roomBounds, floorTile, wallTile, doorTile);
                break;

            case RoomType.Speical:
                break;

            case RoomType.Chest:
                floorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.chestStaticAttr.floorTile;
                wallTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.chestStaticAttr.wallTile;
                doorTile = levelRepository.GetLevelModel(curLevel).LevelStaticAttr.chestStaticAttr.doorTile;

                PaintSingleRoom(newRoom, roomBounds, floorTile, wallTile, doorTile);
                break;
        }

        return newRoom;
    }

    private void PaintSingleRoom(GameObject newRoom, BoundsInt roomBounds, TileBase floorTile, TileBase wallTile, TileBase doorTile)
    {
        var xMin = roomBounds.xMin;
        var xMax = roomBounds.xMax;
        var yMin = roomBounds.yMin;
        var yMax = roomBounds.yMax;
        var size = roomBounds.size;

        // generate Floor
        for (int x = xMin; x <= xMax; x++)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "Floor").
                    SetTile(new Vector3Int(x, y), floorTile);
            }
        }

        for (int x = xMin + size.x / 2 - 2; x <= xMin + size.x / 2 + 2; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "Floor").
                    SetTile(new Vector3Int(x, yMin), doorTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "Floor").
                    SetTile(new Vector3Int(x, yMax), doorTile);
        }

        for (int y = yMin + size.y / 2 - 2; y <= yMin + size.y / 2 + 2; y++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "Floor").
                    SetTile(new Vector3Int(xMin, y), doorTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "Floor").
                    SetTile(new Vector3Int(xMax, y), doorTile);
        }

        // generate WallUp
        for (int y = yMax - size.y / 2 + 2; y <= yMax; y++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(xMin, y), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(xMax, y), wallTile);
        }

        for (int x = xMin + 1; x <= xMin + size.x / 2 - 3; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(x, yMax), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(x, yMax - 1), wallTile);
        }

        for (int x = xMax - size.x / 2 + 3; x <= xMax - 1; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(x, yMax), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallUp").
                    SetTile(new Vector3Int(x, yMax - 1), wallTile);
        }

        // generate WallDown
        for (int y = yMin - 1; y <= yMin + size.y / 2 - 3; y++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(xMin, y), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(xMax, y), wallTile);
        }

        for (int x = xMin + 1; x <= xMin + size.x / 2 - 3; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(x, yMin), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(x, yMin - 1), wallTile);
        }

        for (int x = xMax - size.x / 2 + 3; x <= xMax - 1; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(x, yMin), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDown").
                    SetTile(new Vector3Int(x, yMin - 1), wallTile);
        }

        // generate WallDoorUp
        for (int x = xMin + size.x / 2 - 2; x <= xMin + size.x / 2 + 2; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorUp").
                    SetTile(new Vector3Int(x, yMax), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorUp").
                    SetTile(new Vector3Int(x, yMax - 1), wallTile);
        }

        // generate WallDoorDown
        for (int x = xMin + size.x / 2 - 2; x <= xMin + size.x / 2 + 2; x++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorDown").
                    SetTile(new Vector3Int(x, yMin), wallTile);
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorDown").
                    SetTile(new Vector3Int(x, yMin - 1), wallTile);
        }

        // generate WallDoorLeft
        for (int y = yMin + size.y / 2 - 3; y <= yMin + size.y / 2 + 2; y++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorLeft").
                    SetTile(new Vector3Int(xMin, y), wallTile);
        }

        // generate WallDoorRight
        for (int y = yMin + size.y / 2 - 3; y <= yMin + size.y / 2 + 2; y++)
        {
            UnityTools.Instance.GetComponentFromChildren<Tilemap>(newRoom, "WallDoorRight").
                    SetTile(new Vector3Int(xMax, y), wallTile);
        }
    }

    private void PaintSingleCorridor(GameObject newCorridor, BoundsInt corridorBounds, TileBase floorTile, TileBase wallTile)
    {
        var xMin = corridorBounds.xMin;
        var xMax = corridorBounds.xMax;
        var yMin = corridorBounds.yMin;
        var yMax = corridorBounds.yMax;
        var size = corridorBounds.size;

        // generate floor
        for (int x = xMin; x <= xMax; x++)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Floor").
                        SetTile(new Vector3Int(x, y), floorTile);
            }
        }

        // generate wall
        if (size.x > size.y)
        {
            for (int x = xMin; x <= xMax; x++)
            {
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(x, yMin - 2), wallTile);
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(x, yMin - 1), wallTile);
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(x, yMax - 1), wallTile);
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(x, yMax), wallTile);
            }
        }
        else
        {
            for (int y = yMin - 2; y <= yMax + 1; y++)
            {
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(xMin - 1, y), wallTile);
                UnityTools.Instance.GetComponentFromChildren<Tilemap>(newCorridor, "Wall").
                        SetTile(new Vector3Int(xMax, y), wallTile);
            }
        }
    }

    private void AddPath(Room room1, Room room2)
    {
        Vector2Int pos1 = (Vector2Int)room1.bounds.position;
        Vector2Int pos2 = (Vector2Int)room2.bounds.position;

        if (pos1.x == pos2.x)
        {
            if (pos1.y > pos2.y)
            {
                room1.corridors.Add(Vector2Int.down);
                room2.corridors.Add(Vector2Int.up);
            }
            else
            {
                room1.corridors.Add(Vector2Int.up);
                room2.corridors.Add(Vector2Int.down);
            }
        }
        else
        {
            if (pos1.x > pos2.x)
            {
                room1.corridors.Add(Vector2Int.left);
                room2.corridors.Add(Vector2Int.right);
            }
            else
            {
                room1.corridors.Add(Vector2Int.right);
                room2.corridors.Add(Vector2Int.left);
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
            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].corridors)
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
                if (roomMatrix[roomPos.x, roomPos.y].corridors.Contains(path)) continue;

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
        float targetDis = UnityTools.GetRandomFloat(0f, distanceTotal);
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
            Vector2Int newPos = roomPos + Dir[UnityTools.GetRandomInt(0, 3)];

            if (!IsGeneratable(newPos)) continue;

            return newPos;
        }

        return roomPos;
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

            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].corridors)
            {
                Vector2Int newPos = roomPos + path;
                if (visited[newPos.x, newPos.y]) continue;

                InstantiateCorridors(roomMatrix[roomPos.x, roomPos.y], roomMatrix[newPos.x, newPos.y]);
                queue.Enqueue(newPos);
            }

            visited[roomPos.x, roomPos.y] = true;
        }
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

            foreach (Vector2Int path in roomMatrix[roomPos.x, roomPos.y].corridors)
            {
                Vector2Int newPos = roomPos + path;
                if (visited[newPos.x, newPos.y]) continue;

                OpenDoor(roomMatrix[roomPos.x, roomPos.y], roomMatrix[newPos.x, newPos.y]);
                queue.Enqueue(newPos);
            }

            visited[roomPos.x, roomPos.y] = true;
        }
    }

    public void CreateLevel(LevelType levelType)
    {
        var levelStaticAttr = levelRepository.GetLevelModel(levelType).LevelStaticAttr;
        var startPos = new Vector2Int(UnityTools.GetRandomInt(0, 1000), UnityTools.GetRandomInt(0, 1000));

        curLevel = levelType;
        Refresh();

        // 普通关卡生成5-7个房间
        int curRoomCount = 0;
        int roomCount = UnityTools.GetRandomInt(5, 7);

        // 构建大本营
        Vector2Int curPos = birthPos;

        BoundsInt roomBounds = new BoundsInt((Vector3Int)(startPos + curPos * UnitSize), new Vector3Int(17 - 1, 17 - 1));
        roomMatrix[curPos.x, curPos.y] = new BirthRoom(curLevel, RoomType.Birth, roomBounds, InstantiateRooms(RoomType.Birth, roomBounds));
        curRoomCount++;

        // 构建第一个房间
        // 生成路径
        curPos = birthPos + Dir[UnityTools.GetRandomInt(0, 3)];

        //生成房间
        roomBounds = new BoundsInt((Vector3Int)(startPos + curPos * UnitSize), new Vector3Int(17 - 1, 17 - 1));
        roomMatrix[curPos.x, curPos.y] = new NormalRoom(curLevel, RoomType.Normal, roomBounds, InstantiateRooms(RoomType.Normal, roomBounds));
        AddPath(roomMatrix[curPos.x, curPos.y], roomMatrix[birthPos.x, birthPos.y]);
        curRoomCount++;

        // 构建所有Normal房间
        Vector2Int extendablePos;
        while (curRoomCount < roomCount)
        {
            extendablePos = GetExtendablePos();
            curPos = GetGeneratable(extendablePos);// 从周围四个方向找一个generatable的

            // 生成房间
            if (curRoomCount == roomCount - 1)
            {
                roomBounds = new BoundsInt((Vector3Int)(startPos + curPos * UnitSize), new Vector3Int(17 - 1, 17 - 1));
                roomMatrix[curPos.x, curPos.y] = new TransmissionRoom(curLevel, RoomType.Transmission, roomBounds, InstantiateRooms(RoomType.Transmission, roomBounds));
            }
            else if (curRoomCount == roomCount - 2)
            {
                roomBounds = new BoundsInt((Vector3Int)(startPos + curPos * UnitSize), new Vector3Int(17 - 1, 17 - 1));
                roomMatrix[curPos.x, curPos.y] = new ChestRoom(curLevel, RoomType.Chest, roomBounds, InstantiateRooms(RoomType.Chest, roomBounds));
            }
            else
            {
                roomBounds = new BoundsInt((Vector3Int)(startPos + curPos * UnitSize), new Vector3Int(17 - 1, 17 - 1));
                roomMatrix[curPos.x, curPos.y] = new NormalRoom(curLevel, RoomType.Normal, roomBounds, InstantiateRooms(RoomType.Normal, roomBounds));
            }

            AddPath(roomMatrix[curPos.x, curPos.y], roomMatrix[extendablePos.x, extendablePos.y]);
            curRoomCount++;
        }


        InstantiateLevel();
        OpenAllDoor();

        Debug.Log(roomCount + "个房间");
        EventCenter.Instance.NotifyEvent(EventType.OnFinishRoomCreate);
    }
}