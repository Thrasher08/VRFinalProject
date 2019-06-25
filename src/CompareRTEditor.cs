using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(CompareRT))]
public class CompareRTEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CompareRT basescript = (CompareRT)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        if (GUILayout.Button("Compare"))
        {
            basescript.Compare();
        }
    }
}
