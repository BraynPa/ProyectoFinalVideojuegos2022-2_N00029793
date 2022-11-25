using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col2 : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        ControladorJuego.Col2 = true;
    }

}
