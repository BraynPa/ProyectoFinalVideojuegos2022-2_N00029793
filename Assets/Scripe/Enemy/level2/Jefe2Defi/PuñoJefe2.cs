using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuñoJefe2 : MonoBehaviour
{
    public float dañoAtaque;
    private Transform controladorAtaque;
    private void Start() {
        controladorAtaque = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CombatePlayer>().TomarDaño(dañoAtaque,controladorAtaque.position,1,3,0.1f);
        }
        
    }
}
