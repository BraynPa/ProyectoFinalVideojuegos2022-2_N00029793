using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeLvl1 : MonoBehaviour, IDaño
{
   
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;
    [SerializeField] private GameObject Uno;

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
        Debug.Log(ControladorJuego.escena);
    }
    private void Update()
    { 
        float distanciaJugador = Vector2.Distance(transform.position,jugador.position);
        animator.SetFloat("DistanciaJugador", distanciaJugador); 
    }

    public void TomarDaño(float daño)
    {
        ControladorJuego.totalDaño += daño;
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0)
        {
            activeExplosion();
            animator.SetTrigger("Muerte");
        }
    }
    public void activeExplosion(){
        AudioManager.instance.PlayAudio(AudioManager.instance.explosion1);
    }
    public void activePatada(){
        AudioManager.instance.PlayAudio(AudioManager.instance.enemigoPatada);
    }
    private void Muerte()
    {
        Uno.SetActive(true);
        Destroy(gameObject);
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
    
   
}
