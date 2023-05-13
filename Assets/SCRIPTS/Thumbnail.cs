using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Thumbnail : MonoBehaviour
{

    public ThumbnailData thumbnailData;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image image;
    public static TextMeshProUGUI generalTitle;

   private void Start()
    {
        nameText.text = thumbnailData.name;
        descriptionText.text = thumbnailData.Description;
        generalTitle = GameObject.Find("GeneralTitle").GetComponent<TextMeshProUGUI>();
        image.sprite = thumbnailData.avatar;
    }   
    public void OnSelect()
    {
        generalTitle.text = thumbnailData.Title;
        AnimationManager.instance.SetAnimation(thumbnailData.name, thumbnailData.animSpeed);
    }
   
}
