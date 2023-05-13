using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mixamo/ThumbnailData")]
public class ThumbnailData : ScriptableObject
{

    public string Name;
    public string AnimationName;
    public string Title;
    public string Description;
    public Sprite avatar;
    [Range(0f, 1f)]
    public float animSpeed;

}
