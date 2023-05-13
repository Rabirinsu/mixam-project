using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
        public static PageManager instance;
         public List<GameObject> pages;

    [SerializeField] private static int pageCount;
    [SerializeField] private static int nextpageCount;
    [SerializeField] private static int prevpageCount;
    public static GameObject currentPage;
    public static GameObject nextPage;
    public static GameObject previousPage;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        currentPage = pages[pageCount];

        nextpageCount = pageCount+1;
        nextPage = pages[nextpageCount];
        prevpageCount = pageCount - 1;
        previousPage = null;
        
    }
  

    public void NextPage()
    {
        if (nextPage )
        {
            currentPage.SetActive(false);
            nextPage.SetActive(true);
            previousPage = currentPage;
            currentPage =nextPage;
            pageCount++;
            nextpageCount = pageCount + 1;
            if (pages[pageCount])
            {
                nextPage = pages[pageCount];
            }
        }
    }

    public void PrevPage()
    {
        if (previousPage)
        {
            currentPage.SetActive(false);
            previousPage.SetActive(true);
            nextPage = currentPage;
            currentPage = previousPage;
            pageCount--;
            prevpageCount = pageCount - 1;
            if (pages[prevpageCount])
            {
                previousPage = pages[prevpageCount];
            }
        }
    }


}
