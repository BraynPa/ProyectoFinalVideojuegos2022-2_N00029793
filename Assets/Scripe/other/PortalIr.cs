using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalIr : MonoBehaviour
{
    private bool active = false;
    private float timer = 0;
    private bool contar = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            Timer();
            StartTimer();
            if(timer > 1){
                 SceneManager.LoadScene(2);
            }
        }
    }
    public void Timer(){
        if(contar)
        timer += Time.deltaTime;
    }
    public void StartTimer(){
        contar = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Player") && Palanca.activo){

            AudioManager.instance.PlayAudio(AudioManager.instance.levelComplete);
            active = true;
            
        }
    }
    
}
