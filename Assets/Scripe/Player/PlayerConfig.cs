using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour
{   
    #region Variables
    public float velocity = 0;
    public float jumpForce = 8;
    const float defaultVelocity = 10;
    private float valor = 0;
    private float timer = 0;
    private bool contar = false;
    private bool tocandoSuelo;
    private Vector2 direction;
    const int quieto = 0;
    const int correr = 1;
    const int saltar = 2;
    const int deslizar = 3;
    const int herido = 4;
    const int muerto = 10;
    const int gun = 12;
    public static bool lugarBala;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(velocity==0 && valor==0 )
            SetAnimation(quieto);
        if(velocity==0 && valor==1)
            SetAnimation(saltar);

        if(Input.GetButtonDown("Fire1")){
            Disparo();
        }
        
        Timer();
        Movement();
    }
    public void Movement(){
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            WalkToLeft();
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            StopWalk();
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            WalkToRight();
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            StopWalk();
        if(velocity==10 || velocity == -10 ){
            SetAnimation(correr);
        }

        Run();
        BestJump();
        if(Input.GetKeyDown(KeyCode.Space) && tocandoSuelo ==true)
        {
            Debug.Log(tocandoSuelo);
            tocandoSuelo = false;
            Jump();
        }   
        if(Input.GetKeyUp(KeyCode.Space))
            StopJump();
        
    }
    public void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
        valor = 1;
    }
    public void StopJump(){
       valor=0;

    }
    public void WalkToLeft(){
        velocity = -defaultVelocity;
    }
    public void WalkToRight(){
        velocity = defaultVelocity;
    }
    public void StopWalk(){
        velocity = 0;
    }
    public void Run(){
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        if(velocity < 0)
            sr.flipX = true;
            lugarBala = true;
            if(velocity > 0){
                sr.flipX = false;
                lugarBala = false;
                //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
            
        
    }
    public void SetAnimation(int animation){
        animator.SetInteger("Valor", animation);
    }
    public void BestJump(){
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;

        }else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)){
           rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
 
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
    private void Disparo(){
        Debug.Log("Crear Bala");
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
        
    }
     public void OnCollisionEnter2D(Collision2D laCosa)
    {
        if(laCosa.gameObject.tag == "Suelo" ) //si el cuerpo de lacosa que yo choque tiene tag suelo
        {
            //Debug.Log("Tocando Suelo");
            tocandoSuelo = true; 
        }
        if(laCosa.gameObject.tag == "DeathZone" ) //si el cuerpo de lacosa que yo choque tiene tag DeathZone
        {
            //Debug.Log("Toco DeathZone");
            tocandoSuelo = true; 
            Destroy(this.gameObject);
        }
        /*if(laCosa.gameObject.tag == "Zombie" && atacaConKatana ) 
        {   
            Destroy(laCosa.gameObject);
            atacaConKatana = false;
            edit.ZombiesM += 1;
        }*/
        /*if(laCosa.gameObject.tag == "Zombie" ) 
        {
            anim.SetBool("muerto",true);
        }*/
        
    }
    /*public void OnTriggerEnter2D(Collider2D laCosa)
    {
        if(laCosa.gameObject.tag == "Moneda2" ) 
        {
            edit.moneda2 += 1;
        }
    }
        */
  
}
