using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageControl : MonoBehaviour
{
    private List<GameObject> pages;


    [SerializeField] private Button nextpageButton;
    [SerializeField] private Button prevpageButton;
    [SerializeField] private Scrollbar scrollbar;
    private void Start()
    {
        nextpageButton.onClick.AddListener(NextPage);
        prevpageButton.onClick.AddListener(PreviousPage);
    }
    private void OnEnable()
    {
        scrollbar.value = 1f;
    }
    public void NextPage()
    {
        PageManager.instance.NextPage();
       
    } 
    
    public void PreviousPage()
    {
      
        PageManager.instance.PrevPage();

    }
}
