using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe2Aparecer : MonoBehaviour
{
    [SerializeField] private GameObject Muro;
    [SerializeField] private GameObject Jefe2;
    [SerializeField] private GameObject BarraDeVida;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") ){
           Muro.SetActive(true);
           StartCoroutine(DesactivarColision(2));
           Jefe2.SetActive(true);
           StartCoroutine(DesactivarColision(2  ));
           BarraDeVida.SetActive(true);
        }


    }
    private IEnumerator DesactivarColision(int i)
    {
        yield return new WaitForSeconds(i); 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
