using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2 : MonoBehaviour, IDaño
{
    Animator animator;
    Rigidbody2D rb;
    public float speed;
    [Header("Vida")]

    [SerializeField] private float vida;
    [Header("Ataque")]

    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;
     private float timer = 0;
    private bool contar = false;
    void Start()
    {
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
       speed *=-1;
    }

    
    void Update()
    {
        if(vida > 0){
        Timer();
        StartTimer();
        if(timer > 1){
            animator.SetTrigger("run");
            rb.velocity = new Vector2(speed,rb.velocity.y);
            if(timer > 4){
                animator.SetTrigger("Atack");
                rb.velocity = new Vector2(0,0);
            }
            if(timer > 5.5f){
                animator.SetTrigger("run");
                rb.velocity = new Vector2(speed,rb.velocity.y);
                ResetTimer();
            }
        }
        }
            
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
     public void TomarDaño(float daño)
    {  
        ControladorJuego.totalDaño += daño;
        vida -= daño;
        if(vida <= 0)
        {
            animator.SetTrigger("Death");
        }if(vida > 0){
            animator.SetTrigger("Damage");
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
