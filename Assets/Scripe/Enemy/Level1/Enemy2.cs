using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour,IDaño
{
    public float speed;
    public Rigidbody2D rb;
    public bool tocandoSuelo;
    public SpriteRenderer spr;
    public Animator animator;
    const int run = 1;
    const int atacar = 2;
    const int morir = 3;
    public int x;
    private float timer = 0;
    private bool contar = false;
     public Transform jugador;
    private bool mirandoDerecha = false;
    [Header("ObjetosManipular")]
    [SerializeField] private GameObject Uno;
    [SerializeField] private GameObject Dos;
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Text2;
    [Header("Vida")]

    [SerializeField] private float vida;
    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        speed *=-1;

    }

    // Update is called once per frame
    void Update()
    {
        if(vida > 0){
        Timer();
        StartTimer();
        if(timer > 1){
            SetAnimation(run);
            rb.velocity = new Vector2(speed,rb.velocity.y);
            if(timer > 4){
                SetAnimation(atacar);
                rb.velocity = new Vector2(0,0);
            }
            if(timer > 5.5f){
                SetAnimation(run);
                rb.velocity = new Vector2(speed,rb.velocity.y);
                ResetTimer();
            }
        }
        }
            
    }
    public void audio(){
        AudioManager.instance.PlayAudio(AudioManager.instance.enemigo3Attack);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.tag == "Limit1")
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *=-1;
        }
        if (collider.gameObject.tag == "Limit2")
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *=-1;
        }
    }
    public void Timer(){
        if(contar)
        timer += Time.deltaTime;
    }
    public void ResetTimer(){
        timer = 0;
    }
    public void StartTimer(){
        contar = true;
    }
    public void StopTimer(){
        contar = false;
    }
    public void SetAnimation(int animation){
        animator.SetInteger("Valor", animation);
    }
     public void TomarDaño(float daño)
    {
        vida -= daño;
        Debug.Log("recibi daño");
        if(vida <= 0)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.enemigoMuere);
            Debug.Log("mori");
            SetAnimation(morir);
        }
    }
    private void Muerte()
    {
        Text.SetActive(false);
        Text2.SetActive(true);
        Uno.SetActive(false);
        Dos.SetActive(false);
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
