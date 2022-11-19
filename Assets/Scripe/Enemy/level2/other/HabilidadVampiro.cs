using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadVampiro : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    private Animator animator;
    
     private void Start(){
        animator = GetComponent<Animator>();
    }
    void Update()
    { 
        animator.SetTrigger("Move");
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CombatePlayer>().TomarDaño(daño,1,2,0.05f);
            animator.SetTrigger("Destroy");
        }
        if(other.CompareTag("Suelo"))
        {
            animator.SetTrigger("Destroy");
        }
    
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
