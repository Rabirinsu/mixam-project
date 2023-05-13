using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.SceneManagement;

public class ThumbnailDataAssigner : EditorWindow
{
    [MenuItem("Tools/Assign Thumbnail Data")]
    public static void ShowWindow()
    {
       GetWindow(typeof(ThumbnailDataAssigner));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Assign Thumbnail Data"))
        {
            var thumbnailScripts = FindObjectsOfType<Thumbnail>();
            var thumbnailDataObjects = Resources.LoadAll<ThumbnailData>("ScriptableObjects/Animations");

            if (thumbnailScripts.Length == 0)
            {
                Debug.LogWarning("No thumbnail objects found in scene.");
                return;
            }

            if (thumbnailDataObjects.Length == 0)
            {
                Debug.LogWarning("No thumbnail data objects found in Resources/ThumbnailData folder.");
                return;
            }

            for (int i = 0; i < thumbnailScripts.Length; i++)
            {
                var thumbnail = thumbnailScripts[i];
                var thumbnailData = thumbnailDataObjects[i];
                thumbnail.thumbnailData = thumbnailData;
                EditorUtility.SetDirty(thumbnailScripts[i]);
            }

                Debug.Log("found scriptable objects " + thumbnailDataObjects.Length + "scripts "+ thumbnailScripts.Length);

        /*    var scenePath = EditorSceneManager.GetActiveScene().path;
              EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), scenePath);
            AssetDatabase.SaveAssets();*/
        }
    }
}
