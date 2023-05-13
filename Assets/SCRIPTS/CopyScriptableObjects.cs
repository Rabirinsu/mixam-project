using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CopyScriptableObjects : EditorWindow
{
    private ThumbnailData sourcescriptableobject;
    private MonoScript scriptToCopy;
    private int numberOfCopies = 0;

    [MenuItem("Tools/CopyScriptableObjects")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<CopyScriptableObjects>("CopyScriptableObjects");
    }

    private void OnGUI()
    {
        sourcescriptableobject = EditorGUILayout.ObjectField("Scriptable Object", sourcescriptableobject, typeof(ThumbnailData), false) as ThumbnailData;
        numberOfCopies = EditorGUILayout.IntField("Number of Copies", numberOfCopies);
        scriptToCopy = EditorGUILayout.ObjectField("Script To Copy", scriptToCopy, typeof(MonoScript), false) as MonoScript;

        if (sourcescriptableobject == null || numberOfCopies <= 0)
            return;

        if (GUILayout.Button("Create Copies"))
        {
            for (int i = 0; i < numberOfCopies; i++)
            {
                ThumbnailData newScriptableObject = CreateInstance<ThumbnailData>();
                 
                AssetDatabase.CreateAsset(newScriptableObject,AssetDatabase.GetAssetPath(sourcescriptableobject) + sourcescriptableobject.name + i + ".asset");
                AssetDatabase.SaveAssets();
            }
            Debug.Log(numberOfCopies + " copies of " + sourcescriptableobject.name + " have been created.");
        }
    }

}
