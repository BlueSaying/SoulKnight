using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : Graphic
{
    private class Line
    {
        public Vector2 startPoint;
        public Vector2 endPoint;
        public Color color;
        public float thickness;

        public Line(Vector2 startPoint, Vector2 endPoint, Color color, float thickness)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.color = color;
            this.thickness = thickness;
        }
    }

    private List<Line> lines = new List<Line>();

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        for (int i = 0; i < lines.Count; i++)
        {
            Vector2 startPoint = lines[i].startPoint;
            Vector2 endPoint = lines[i].endPoint;
            Color color = lines[i].color;
            float thickness = lines[i].thickness;

            Vector2 dir = (endPoint - startPoint).normalized;

            Vector2 norm = new Vector2(-dir.y, dir.x) * thickness / 2;

            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            vertex.position = startPoint - norm;
            vh.AddVert(vertex);

            vertex.position = startPoint + norm;
            vh.AddVert(vertex);

            vertex.position = endPoint + norm;
            vh.AddVert(vertex);

            vertex.position = endPoint - norm;
            vh.AddVert(vertex);

            // 添加三角形（两个三角形组成矩形）
            vh.AddTriangle(4 * i, 4 * i + 1, 4 * i + 2);
            vh.AddTriangle(4 * i + 2, 4 * i + 3, 4 * i);
        }
    }

    public void Refresh()
    {
        lines.Clear();
        SetVerticesDirty();
    }

    public void RendererLine(Vector2 startPoint, Vector2 endPoint, Color color, float thickness = 10f)
    {
        lines.Add(new Line(startPoint, endPoint, color, thickness));
        SetVerticesDirty();
    }
}
