using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadJefe2 : MonoBehaviour
{
    [SerializeField] private float daño;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
    [SerializeField] private float tiempoDeVida;


    void Start()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.espadaJefe3Cae);
        Destroy(gameObject, tiempoDeVida);
    }

    // Update is called once per frame
    public  void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);

        foreach (Collider2D collisiones in objetos)
        {
            if(collisiones.CompareTag("Player"))
            {
                collisiones.GetComponent<CombatePlayer>().TomarDaño(daño, posicionCaja.position,2,3,0.2f);
                
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicionCaja.position, dimensionesCaja);
    }
}
