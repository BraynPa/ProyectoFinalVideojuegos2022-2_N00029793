using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;//posicion Golpe
    [SerializeField] private float radioGolpe;//El radio de ataque es circular
    [SerializeField] private float dañoGolpe;//El daño que hace
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;


    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    
    private void Update() {

        if(tiempoSiguienteAtaque>0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.C) && tiempoSiguienteAtaque <= 0)
        {   
            //Debug.Log("GOLPE");
            Golpe();
            tiempoSiguienteAtaque=tiempoEntreAtaques;
        }
    }
    private void Golpe(){

        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position,radioGolpe);//Se le envia la posicion y el radio para generarlo

        foreach (Collider2D colisionador in objetos)//Recorremos los objetos
        {
           IDaño objeto = colisionador.GetComponent<IDaño>();
           if(objeto != null)
           {
            objeto.TomarDaño(dañoGolpe);
           }
        }
        
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
    
}
