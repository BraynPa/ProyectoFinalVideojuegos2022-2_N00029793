using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAguaDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.GetComponent<CombatePlayer>().TomarDaño(100,2,2,0.5f);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.GetComponent<CombatePlayer>().TomarDaño(100,2,2,0.5f);

        }
    }
}
