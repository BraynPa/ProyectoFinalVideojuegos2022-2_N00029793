using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Uno;
    [SerializeField] private GameObject Suelo;
    [SerializeField] private GameObject Plataforma;
    [SerializeField] private GameObject Dos;
    [SerializeField] private GameObject Tres;
    [SerializeField] private GameObject Cuatro;
    private bool IsPlayerInRange;
    public static bool activo = false;
    private int valor = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerInRange && Input.GetKeyUp(KeyCode.V) && valor == 0){
            AudioManager.instance.PlayAudio(AudioManager.instance.palanca);
            activo = true;
            Uno.SetActive(false);
            Dos.SetActive(true);
            Tres.SetActive(false);
            Cuatro.SetActive(true);
            Suelo.SetActive(true);
            Plataforma.SetActive(true);
            valor = 1;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Player") && valor == 0){
            IsPlayerInRange = true;
            Text.SetActive(true);
            
        }

        

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && valor == 0 ){
            IsPlayerInRange = false;
            Text.SetActive(false);
            
        }
    }
}
