using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder
{
    private static readonly List<Vector2Int> Dir = new List<Vector2Int>()
    {
        new Vector2Int(1,0),
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),
        new Vector2Int(-1,1),
        new Vector2Int(0,1),
        new Vector2Int(1,1),
    };

    private NavigationMeshBuilder navigationMeshBuilder;
    public NavigationMeshBuilder NavigationMeshBuilder
    {
        get
        {
            if (navigationMeshBuilder == null) navigationMeshBuilder = GameObject.Find("NavigationMesh").GetComponent<NavigationMeshBuilder>();
            if (navigationMeshBuilder == null) throw new System.Exception("未添加NavigationMesh Component");
            return navigationMeshBuilder;
        }
    }

    private int width;
    private int height;
    private NavigationNode[,] nodes;

    private List<NavigationNode> openList = new List<NavigationNode>();
    private List<NavigationNode> closeList = new List<NavigationNode>();

    public PathFinder()
    {
        width = NavigationMeshBuilder.width;
        height = NavigationMeshBuilder.height;
        nodes = NavigationMeshBuilder.navigationNodes;
    }

    private bool IsOutOfMap(Vector2Int pos)
    {
        return pos.x >= width || pos.y >= height || pos.x < 0 || pos.y < 0;
    }

    private float EuclidDistance(Vector2Int pos1, Vector2Int pos2)
    {
        return Vector2Int.Distance(pos1, pos2);
    }

    private float ManhattanDistance(Vector2Int pos1, Vector2Int pos2)
    {
        return Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y);
    }

    // A*寻路
    public List<Vector2> FindPath(Vector2 startPos, Vector2 endPos)
    {
        Vector2Int start = NavigationMeshBuilder.WorldToMeshPoint(startPos);
        Vector2Int end = NavigationMeshBuilder.WorldToMeshPoint(endPos);
        Debug.Log(start + end);
        if (IsOutOfMap(start) || IsOutOfMap(end)) return null;
        if (nodes[start.x, start.y].nodeType == NodeType.Obstacle || nodes[end.x, end.y].nodeType == NodeType.Obstacle) return null;

        openList = new List<NavigationNode>();
        closeList = new List<NavigationNode>();

        nodes[start.x, start.y].parent = null;
        nodes[start.x, start.y].g = 0;
        nodes[start.x, start.y].h = ManhattanDistance(start, end);
        openList.Add(nodes[start.x, start.y]);

        while (openList.Count > 0)
        {
            openList.Sort((a, b) => { return a.f.CompareTo(b.f); });
            Vector2Int curPos = openList[0].nodePos;
            closeList.Add(openList[0]);
            openList.RemoveAt(0);

            // judge if we have found the end
            if (curPos == end)
            {
                var result = new List<Vector2>();

                while (nodes[curPos.x, curPos.y].parent != null)
                {
                    result.Add(NavigationMeshBuilder.MeshToWorldPoint(nodes[curPos.x, curPos.y].nodePos));
                    curPos = nodes[curPos.x, curPos.y].parent.nodePos;
                }

                result.Reverse();

                return result;
            }

            // 添加可添加的node到openList中
            foreach (var dir in Dir)
            {
                Vector2Int newPos = curPos + dir;
                if (IsOutOfMap(newPos) || closeList.Contains(nodes[newPos.x, newPos.y])
                || nodes[newPos.x, newPos.y].nodeType == NodeType.Obstacle) continue;

                if (openList.Contains(nodes[newPos.x, newPos.y]))
                {
                    if (nodes[newPos.x, newPos.y].g > nodes[curPos.x, curPos.y].g + EuclidDistance(newPos, curPos))
                    {
                        nodes[newPos.x, newPos.y].parent = nodes[curPos.x, curPos.y];
                        nodes[newPos.x, newPos.y].g = nodes[curPos.x, curPos.y].g + EuclidDistance(newPos, curPos);
                    }
                }
                else
                {
                    nodes[newPos.x, newPos.y].parent = nodes[curPos.x, curPos.y];
                    nodes[newPos.x, newPos.y].g = nodes[curPos.x, curPos.y].g + EuclidDistance(newPos, curPos);
                    nodes[newPos.x, newPos.y].h = ManhattanDistance(newPos, end);
                    openList.Add(nodes[newPos.x, newPos.y]);
                }
            }
        }


        return null;
    }
}