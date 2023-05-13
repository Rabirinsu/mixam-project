using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ProcessAnimations : MonoBehaviour
{
    private string modelfolderPath = "Assets/Animations";
    private string fbxPath = "Assets/Resources/Animations/Bboy Uprock Start.fbx";
  /*  public void OnPreprocessAnimation(string fbxPath)
    {

        AssetDatabase.ImportAsset(fbxPath, ImportAssetOptions.Default);

        var modelImporter = AssetImporter.GetAtPath(fbxPath) as ModelImporter;


        ModelImporterClipAnimation clip = modelImporter.clipAnimations[0]; // get first clip
      var  clipname = clip.name;
        clip.wrapMode = WrapMode.Loop;
        Debug.Log(clipname);

    }*/
    public void OnPreprocessAnimation()
    {
        AssetDatabase.ImportAsset(fbxPath, ImportAssetOptions.Default);
        var modelImporter = AssetImporter.GetAtPath(fbxPath) as ModelImporter;
        ModelImporterClipAnimation clip = modelImporter.clipAnimations[0]; // get first clip
        clip.wrapMode = WrapMode.Loop;
        var  clipname = clip.name;
        Debug.Log(clipname);

    }

  

}
