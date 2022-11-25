using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCaracteristicas : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(ControladorJuego.Col2){
            animator.SetTrigger("activo");
        }
    }
}
