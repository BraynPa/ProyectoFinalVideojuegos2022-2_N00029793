using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public List<GameObject> plataformas; 
    private MovePlayer movimientoJugador;

    private void Start()
    {
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
        movimientoJugador.OnJump += Activar;
    }

    private void Activar(object sender, EventArgs e) 
    {
        foreach (GameObject item in plataformas)
        {
            item.SetActive(!item.activeSelf);
        }
    }

}
