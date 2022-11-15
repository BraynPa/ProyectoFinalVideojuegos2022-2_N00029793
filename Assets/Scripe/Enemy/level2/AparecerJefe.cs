using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerJefe : MonoBehaviour
{
    [SerializeField] private GameObject Uno;
    [SerializeField] private GameObject Dos;
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Uno.SetActive(true);
            Dos.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
