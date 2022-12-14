using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad2jefe : MonoBehaviour
{
    [SerializeField] private float Daño;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.GetComponent<CombatePlayer>().TomarDaño(Daño,2,2,0.5f);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.GetComponent<CombatePlayer>().TomarDaño(Daño,2,2,0.5f);

        }
    }
}
