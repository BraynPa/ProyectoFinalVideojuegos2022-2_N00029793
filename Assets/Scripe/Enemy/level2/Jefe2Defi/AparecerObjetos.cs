using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerObjetos : MonoBehaviour
{
    [SerializeField] private GameObject Jefe2;
    [SerializeField] private GameObject BarraDeVida;
    private Caida caida;
    void Start()
    {
        caida = GameObject.FindGameObjectWithTag("MuroCaida").GetComponent<Caida>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") ){
           caida.ActiveCaida();
           Jefe2.SetActive(true);
           BarraDeVida.SetActive(true);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
