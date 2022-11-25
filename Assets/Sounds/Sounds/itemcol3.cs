using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcol3 : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!ControladorJuego.Col3){
            animator.SetTrigger("noItem");
        }
    }
}
