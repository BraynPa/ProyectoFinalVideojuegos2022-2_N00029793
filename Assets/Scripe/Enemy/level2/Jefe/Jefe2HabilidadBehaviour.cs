using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe2HabilidadBehaviour : StateMachineBehaviour
{
    [SerializeField] private GameObject HabilidadJefe2;
    [SerializeField] private float offsetY;
    private Jeve2 jefe;
    private Transform jugador;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       jefe = animator.GetComponent<Jeve2>();
       jugador = jefe.jugador;

       jefe.MirarJugador();

       Vector2 posicionAparicion = new Vector2(jugador.position.x, jugador.position.y + offsetY);

       Instantiate(HabilidadJefe2, posicionAparicion, Quaternion.identity);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
}
