using UnityEngine;
using UnityEditor;
using System.IO;

public class SetLoopTimeForFBXAnimations : EditorWindow
{
    private Object folderObject;
    private ModelImporter importer;
    private ModelImporterClipAnimation[] animations;

    [MenuItem("Tools/Set Loop Time for FBX Animations")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<SetLoopTimeForFBXAnimations>("Set Loop Time for FBX Animations");
    }

    private void OnGUI()
    {
        folderObject = EditorGUILayout.ObjectField("Folder Object", folderObject, typeof(DefaultAsset), false);

        if (folderObject == null)
            return;

        string folderPath = AssetDatabase.GetAssetPath(folderObject);

        if (!Directory.Exists(folderPath))
        {
            Debug.LogError("Selected folder path is not valid!");
            return;
        }

        string[] fbxFilePaths = Directory.GetFiles(folderPath, "*.fbx", SearchOption.AllDirectories);

        if (fbxFilePaths.Length == 0)
        {
            Debug.LogError("No FBX files found in the selected folder!");
            return;
        }

        if (GUILayout.Button("Get Animation Settings"))
        {
            foreach (string fbxFilePath in fbxFilePaths)
            {
                importer = AssetImporter.GetAtPath(fbxFilePath) as ModelImporter;
                if (importer != null)
                {
                    animations = importer.defaultClipAnimations;
                    if (animations != null)
                    {
                        for (int i = 0; i < animations.Length; i++)
                        {
                            animations[i].loopTime = true;
                            animations[i].loopPose = true;
                        }
                        importer.clipAnimations = animations;
                        AssetDatabase.ImportAsset(fbxFilePath);
                    }
                }
            }
        }
    }
}