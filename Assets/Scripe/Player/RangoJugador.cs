using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoJugador : MonoBehaviour
{
    private Enemy3 enemy3;

    private void Start(){
       enemy3 = GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Enemy3>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            enemy3.AlertaOn();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            enemy3.AlertaOff();
        }
    }
}
