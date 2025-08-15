using UnityEngine;

public class NavigationNode
{
    public Vector2Int nodePos;

    public NodeType nodeType;

    public NavigationNode parent;

    // 寻路消耗
    public float f => g + h;
    public float g;
    public float h;

    public NavigationNode(Vector2Int nodePos, NodeType nodeType)
    {
        this.nodePos = nodePos;
        this.nodeType = nodeType;
    }
}