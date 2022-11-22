using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaHielo : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private GameObject hielo;
    [SerializeField] private float tiempoEntreHielo;
    private float timer = 0;
    private bool contar = false;
    private int numeroAleatorio;
    private bool active = true;

    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
    }

    void Update()
    {
        Timer();
        StartTimer();
        if(timer > tiempoEntreHielo)
        {
            if(active){
                Instantiate(hielo, puntosMovimiento[numeroAleatorio].position, Quaternion.identity);
                active = false;
            }
            if(timer > tiempoEntreHielo*2){
                numeroAleatorio = Random.Range(0,puntosMovimiento.Length);
                ResetTimer();
                active = true;
            }
        }
    }
     public void Timer(){
        if(contar)
        timer += Time.deltaTime;
    }
    public void ResetTimer(){
        timer = 0;
    }
    public void StartTimer(){
        contar = true;
    }
    public void StopTimer(){
        contar = false;
    }
}
