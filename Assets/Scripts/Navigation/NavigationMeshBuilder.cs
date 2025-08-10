using UnityEngine;

public class NavigationMeshBuilder : MonoBehaviour
{
    [Tooltip("The width of nodes")]
    [SerializeField]
    public int width = 10;

    [Tooltip("The height of nodes")]
    [SerializeField]
    public int height = 10;

    [Tooltip("The size of node")]
    [SerializeField]
    private float nodeSize = 1;

    [Tooltip("The center of mesh")]
    [SerializeField]
    private Vector2 center = Vector2.zero;

    [Tooltip("Layers of the obstacle in map")]
    [SerializeField]
    private LayerMask obstacleLayerMask;

    [Tooltip("Radius of the node")]
    [SerializeField]
    private float nodeRadius = 1f;

    public NavigationNode[,] navigationNodes { get; private set; }

    private void Awake()
    {
        BuildNavigationMesh();
    }

    public Vector2 MeshToWorldPoint(Vector2Int nodePos)
    {
        float x = (nodePos.x - (width - 1) / 2.0f) * nodeSize + center.x;
        float y = (nodePos.y - (height - 1) / 2.0f) * nodeSize + center.y;
        return new Vector2(x, y);
    }

    public Vector2Int WorldToMeshPoint(Vector2 worldPos)
    {
        float x = (worldPos.x - center.x) / nodeSize + (width - 1) / 2.0f;
        float y = (worldPos.y - center.y) / nodeSize + (height - 1) / 2.0f;
        return Vector2Int.RoundToInt(new Vector2(x, y));
    }

    public void BuildNavigationMesh()
    {
        navigationNodes = new NavigationNode[width, height];

        // Optimize
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int nodePos = new Vector2Int(x, y);
                Vector2 worldPos = MeshToWorldPoint(nodePos);
                NodeType nodeType = Physics2D.OverlapPoint(worldPos, obstacleLayerMask) ? NodeType.Obstacle : NodeType.None;

                navigationNodes[x, y] = new NavigationNode(nodePos, nodeType);
            }
        }

        Debug.Log("Navigation Mesh Finished!");
    }
}