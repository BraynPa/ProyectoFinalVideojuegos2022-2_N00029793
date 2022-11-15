using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    
    void Update()
    { 
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    public void AumentarDaño(int dañoExtra){
        daño += dañoExtra * daño;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<JefeLvl1>().TomarDaño(daño);
            Debug.Log("Daño: "+ daño);
            Destroy(gameObject);
        }
        if(other.CompareTag("Enemy2"))
        {
            other.GetComponent<Enemy2>().TomarDaño(daño);
            Debug.Log("Daño: "+ daño);
            Destroy(gameObject);
        }
        if(other.CompareTag("Enemy3"))
        {
            other.GetComponent<Enemy3>().TomarDaño(daño);
            Debug.Log("Daño: "+ daño);
            Destroy(gameObject);
        }
    
    }
}
