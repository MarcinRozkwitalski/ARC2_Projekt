using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGeneration))]
public class NewBehaviourScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapGeneration mapGeneration = (MapGeneration)target;
        if (GUILayout.Button("Generate Levels"))
        {
            mapGeneration.GenerateLevels();
        }
    }
}