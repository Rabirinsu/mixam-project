using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private Animator animator;
    private Vector3 exactpos;
    private void Start()
    {
        animator = GetComponent<Animator>();
        exactpos = transform.localPosition;
    }

    private void LateUpdate()
    {
       
    }
}
