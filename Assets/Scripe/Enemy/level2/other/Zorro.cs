using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zorro : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CombatePlayer>().TomarDaño(35,other.GetContact(0).normal,1.2f,2,0.1f);
        }
        
    
    }
}
