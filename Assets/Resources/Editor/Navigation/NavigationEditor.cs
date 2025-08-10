using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NavigationMeshBuilder))]
public class NavigationEditor : Editor
{
    private NavigationMeshBuilder pathFinder;

    private void Awake()
    {
        pathFinder = (NavigationMeshBuilder)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Build Navigation Mesh"))
        {
            pathFinder.BuildNavigationMesh();
        }
    }
}