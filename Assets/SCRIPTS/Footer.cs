using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.WSA;



public class Footer : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("HoverEnter");

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("HoverExit");
    }
  

}
