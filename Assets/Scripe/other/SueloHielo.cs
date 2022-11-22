using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloHielo : MonoBehaviour
{
    Animator animator;
    private float timer = 0;
    private bool contar = false;
    private bool activo = false;
    [SerializeField] private float tiempoDeVida;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if(activo){
            Timer();
            StartTimer();
            if(timer > tiempoDeVida){
                animator.SetTrigger("destruir");
            }
        }
        
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }
    public void Timer(){
        if(contar)
        timer += Time.deltaTime;
    }
    
    public void StartTimer(){
        contar = true;
    }
    public void OnCollisionEnter2D(Collision2D laCosa)
    {
        
        if(laCosa.gameObject.tag == "Player" ) 
        {
            animator.SetTrigger("loToco");
            activo = true;
            
        }
        
        
    }
}
