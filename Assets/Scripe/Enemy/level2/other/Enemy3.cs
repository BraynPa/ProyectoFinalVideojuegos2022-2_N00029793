using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour, IDaño
{
    private Rigidbody2D rb;
    private Animator animator;
    [Header("Jugador")]
    public Transform jugador;

    [SerializeField] private bool estarAlerta;
    [Header("Variables")]
    [SerializeField] private float speed;
    [SerializeField] private float distancia_frenado;
    [SerializeField] private float distancia_retraso;

    [Header("Vida")]

    [SerializeField] private float vida;
    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;
    private float tiempo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jugador = GameObject.Find("Player").transform;
    }

    void Update()
    {
        

        if(vida > 0 && estarAlerta){



            if(Vector2.Distance(transform.position, jugador.position) > distancia_frenado){
                animator.SetTrigger("Correr");
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
            }
            if(Vector2.Distance(transform.position, jugador.position) < distancia_retraso){
                animator.SetTrigger("Correr");
                transform.position= Vector2.MoveTowards(transform.position, jugador.position, -speed * Time.deltaTime);
            }
            if(Vector2.Distance(transform.position, jugador.position) < distancia_frenado && Vector2.Distance(transform.position, jugador.position) > distancia_retraso){
                transform.position = transform.position;
            }

            if(jugador.position.x>this.transform.position.x){
                this.transform.localScale = new Vector2(1,1);
            }else{
                this.transform.localScale = new Vector2(-1,1);
            }
            tiempo += Time.deltaTime;
            if(tiempo>=3 )
            {
                animator.SetTrigger("Atacar");
                tiempo = 0;
            }

            

        }
    }
    public void AlertaOn(){
        estarAlerta = true;
    }
    public void AlertaOff(){
        estarAlerta = false;
    }

     public void TomarDaño(float daño)
    {
        ControladorJuego.totalDaño += daño;
        vida -= daño;
        animator.SetTrigger("Daño");
        Debug.Log("recibi daño");
        if(vida <= 0)
        {
            Debug.Log("mori");
            animator.SetTrigger("Morir");
        }
    }
    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void Ataque(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D collision in objetos)
        {
            if(collision.CompareTag("Player"))
            {
                collision.GetComponent<CombatePlayer>().TomarDaño(dañoAtaque,controladorAtaque.position,1,2,0.05f);
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);

    }

}
