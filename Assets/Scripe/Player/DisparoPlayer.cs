using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float maximoCarga;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private float tiempoDeCarga;
    private float tiempoSiguienteDisparo;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >=tiempoSiguienteDisparo){
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            if(tiempoDeCarga <= maximoCarga)
            {
                tiempoDeCarga += Time.deltaTime;
            }
        }
        if(Input.GetButtonUp("Fire1") && Time.time >=tiempoSiguienteDisparo){
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            Disparo((int)tiempoDeCarga);
            tiempoDeCarga = 0;
        }
    }
    private void Disparo(int tiempoCarga){
        //Debug.Log("Crear Bala");
        Vector3 crecer = new Vector3(tiempoCarga, tiempoCarga,0);
        GameObject balaObjeto = Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
        balaObjeto.GetComponent<Bala>().AumentarDaño(tiempoCarga);
        balaObjeto.transform.localScale += crecer;

    }
}
