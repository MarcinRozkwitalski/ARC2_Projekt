using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneSwitcher))]
public class SceneManagerEditor : Editor
{
  
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SceneSwitcher sceneSwitcher = (SceneSwitcher)target;
        if (GUILayout.Button("Welcome Scene"))
        {
            sceneSwitcher.LoadPlayerWelcomeScene();
        }
    }
}
