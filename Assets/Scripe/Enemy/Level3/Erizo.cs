using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erizo : MonoBehaviour, IDaño
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;
    [Header("Vida")]

    [SerializeField] private float vida;
    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (informacionSuelo == false){
            Girar();
        }

            
    }
     public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            velocidad = 0;
            Physics2D.IgnoreLayerCollision(7,9, true);
            Muerte();
        }
    }
    private void Muerte()
    {
        Physics2D.IgnoreLayerCollision(7,9, false);
        Destroy(gameObject);
    }
    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;

    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.tag == "Limit1")
        {
            moviendoDerecha = !moviendoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            velocidad *= -1;
        }
        if (collider.gameObject.tag == "Limit2")
        {
            moviendoDerecha = !moviendoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            velocidad *= -1;
        }
    }public void Ataque(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D collision in objetos)
        {
            if(collision.CompareTag("Player"))
            {
                collision.GetComponent<CombatePlayer>().TomarDaño(dañoAtaque,1,2,0.05f);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);

    }
}
