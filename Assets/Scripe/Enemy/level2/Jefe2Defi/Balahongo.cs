using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balahongo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    
    void Update()
    { 
        transform.Translate(Vector2.right * -velocidad * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CombatePlayer>().TomarDaño(daño,1,2,0.05f);
            Destroy(gameObject);
        }else{
            Destroy(gameObject);
        }
    
    }
}
