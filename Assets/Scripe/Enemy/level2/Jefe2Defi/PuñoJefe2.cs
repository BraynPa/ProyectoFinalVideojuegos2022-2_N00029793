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
    public void  impactoGolpe(){
        AudioManager.instance.PlayAudio(AudioManager.instance.impactoGolpe);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            impactoGolpe();
            other.GetComponent<CombatePlayer>().TomarDaño(dañoAtaque,controladorAtaque.position,1,3,0.1f);
        }
        
    }
}
