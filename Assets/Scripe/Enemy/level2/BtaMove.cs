using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BtaMove : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float tiempoAs;
    private Animator animator;
    private int numeroAleatorio;
    private float tiempo;
    private bool finish;

    private void Start(){
        animator = GetComponent<Animator>();
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        finish = false;
    }

    void Update()
    {
        if(finish == true){
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position,velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0,puntosMovimiento.Length);
        }

        tiempo += Time.deltaTime;
            if(tiempo >= tiempoAs)
            {
                Habilidad();
                tiempo = 0;
            }
        }
    }
    public void terminado(){
        finish = true;
    }
    public void Habilidad(){
        animator.SetTrigger("Habilidad");
    }
    private void Disparo(){    
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
