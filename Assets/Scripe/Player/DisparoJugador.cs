using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;

    private void update(){
        
       if(Input.GetButtonDown("Fire1")){
            Disparo();
        }
    }

    private void Disparo(){
        Debug.Log("Crear Bala");
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
