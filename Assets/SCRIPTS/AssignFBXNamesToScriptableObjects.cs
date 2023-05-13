using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.VersionControl;
using System.Linq;

public class AssignFBXNamesToScriptableObjects : EditorWindow
{
    private const string FBX_PATH = "Animations"; // FBX dosyalar?n?n bulundu?u klasör yolu
    private const string SCRIPTABLE_OBJECT_PATH = "ScriptableObjects/Animations"; // ScriptableObject'lerin kaydedilece?i klasör yolu
    private const string SCRIPT_NAME = "ThumbnailData"; // ScriptableObject'lerin ismi

    [MenuItem("Tools/Assign FBX Names to Scriptable Objects")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AssignFBXNamesToScriptableObjects));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Assign FBX Names"))
        {
            // Tüm fbx dosyalar?n? yükle
            Object[] fbxObjects = Resources.LoadAll(FBX_PATH, typeof(GameObject));
            string[] fbxNames = new string[fbxObjects.Length];
            for (int i = 0; i < fbxObjects.Length; i++)
            {
                fbxNames[i] = fbxObjects[i].name;
            }

            // ScriptableObject'leri yükle ve isimlerini fbx isimleriyle de?i?tir
            Object[] scriptableObjects = Resources.LoadAll(SCRIPTABLE_OBJECT_PATH, typeof(ThumbnailData));
            for (int i = 0; i < scriptableObjects.Length; i++)
            {
                ThumbnailData scriptableObject = (ThumbnailData)scriptableObjects[i];
                string newName = fbxNames[i];
                string oldName = scriptableObject.name;
               AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(scriptableObject), newName);
                scriptableObject.Name = newName;
                scriptableObject.AnimationName = newName;
                scriptableObject.Title = newName.ToUpper() + "ON X BOT";
                Debug.Log("Renamed " + oldName + " to " + newName);
            }

            AssetDatabase.SaveAssets();
            Debug.Log("FBX names assigned to ScriptableObjects.");
        }
    }
}
