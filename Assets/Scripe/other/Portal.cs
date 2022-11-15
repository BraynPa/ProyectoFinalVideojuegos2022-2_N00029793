using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
     private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Player") && !Palanca.activo){
            Text.SetActive(true);
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !Palanca.activo){
            Text.SetActive(false);
            
        }
    }
}
