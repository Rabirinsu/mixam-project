using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ProcessAnimations))]

public class ProcessAnimsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var myScript = (ProcessAnimations)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.OnPreprocessAnimation();
        }
    }
}
