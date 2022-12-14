using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeve2 : MonoBehaviour, IDaño
{
   
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;
    [SerializeField] private GameObject Uno;
    [SerializeField] private GameObject Dos;
    [SerializeField] private GameObject Suelo;
    [SerializeField] private GameObject SueloCol;

    [Header("Vida")]

    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDevida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    { 
        float distanciaJugador = Vector2.Distance(transform.position,jugador.position);
        animator.SetFloat("DistanciaJugador", distanciaJugador); 
    }

    public void TomarDaño(float daño)
    {
        ControladorJuego.totalDaño += daño;
        animator.SetTrigger("Damage");
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0)
        {
            animator.SetTrigger("Muerte");
        }
    }
    private void Muerte()
    {
        
        Uno.SetActive(true);
        Destroy(gameObject);
    }
    public void ActiveSuelo(){
        Dos.SetActive(true);
        Suelo.SetActive(true);
        SueloCol.SetActive(true);
    }
    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha)){
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D collision in objetos)
        {
            if(collision.CompareTag("Player"))
            {
  
                collision.GetComponent<CombatePlayer>().TomarDaño(dañoAtaque,controladorAtaque.position,1,3,0.1f);
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
    public void activeCaida(){
        AudioManager.instance.PlayAudio(AudioManager.instance.espadaJefe3Cae);
    }
    public void activeEspada(){
        AudioManager.instance.PlayAudio(AudioManager.instance.espadaJefe3);
    }
    public void activeExplosion(){
        AudioManager.instance.PlayAudio(AudioManager.instance.explosion1);
    }
}

