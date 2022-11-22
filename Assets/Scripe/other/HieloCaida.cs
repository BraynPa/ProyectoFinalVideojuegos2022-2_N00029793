using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieloCaida : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float daño;
    void Start()
    {
        
        transform.rotation = Quaternion.Euler(0,0,-91.362f);
    }


    void Update()
    {
        
    }
    public void Destruye(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CombatePlayer>().TomarDaño(daño,1,2,0.05f);
            animator.SetTrigger("Destroy");
        }
        if(other.CompareTag("Suelo")){
            animator.SetTrigger("Destroy");
        }

    }
}
