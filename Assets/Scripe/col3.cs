using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col3 : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        ControladorJuego.Col3 = true; 
    }

}
