using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerBats : MonoBehaviour
{
    [SerializeField] private GameObject Uno;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Uno.SetActive(true);
            
        }
    }
}
