using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balaice : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    Animator animator;
    
    private void start(){
        animator = GetComponent<Animator>();
    }
    void Update()
    { 
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    public void AumentarDaño(int dañoExtra){
        daño += dañoExtra * daño;
    }
    public void Destruye(){
        animator.SetTrigger("Toco");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        /*if(other.CompareTag("Enemy5"))
        {
            other.GetComponent<Enemy5>().TomarDaño(daño);
            Debug.Log("Daño: "+ daño);
            Destroy(gameObject);
        }*/
        Destruye();

    }
}
