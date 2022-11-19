using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeve2_CaminarBehaviour : StateMachineBehaviour
{
    private Jeve2 jefe;
    private Rigidbody2D rb2D; 
    [SerializeField] private float velocidadMovimiento;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       jefe = animator.GetComponent<Jeve2>();
       rb2D = jefe.rb2D;

       jefe.MirarJugador();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       rb2D.velocity = new Vector2(velocidadMovimiento, rb2D.velocity.y) * animator.transform.right;
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       rb2D.velocity = new Vector2(0, rb2D.velocity.y);
    }

    
}
