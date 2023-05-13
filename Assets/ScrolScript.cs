using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrolScript : MonoBehaviour
{
    [SerializeField] private Scrollbar bar;
  private  void Start()
    {
        bar.value = 1;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
