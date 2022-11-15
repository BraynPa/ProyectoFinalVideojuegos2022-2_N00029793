using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalIr : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Player") && Palanca.activo){
            
            SceneManager.LoadScene(2);
            
        }
    }
    
}
