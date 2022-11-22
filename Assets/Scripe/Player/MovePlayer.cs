using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb2D; 

    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    [Header("Movimiento")]

    private float movimientoHorizontak = 0f;

    [SerializeField] private float velocidadDeMovimiento; 
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    private bool salto = false;
    [Header("SaltoRegulable")]
    [Range(0,1)][SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGravedad;
    private float escalaGravedad;
    private bool botonSaltoArriba = true;



    [Header("Animacion")]

    private Animator animator;

    public event EventHandler OnJump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        escalaGravedad = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontak = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontak));
        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if(Input.GetButton("Jump")){
            salto = true;
        }
        if(Input.GetButtonUp("Jump")){
            BotonSaltoArriba();
        }
        if(Input.GetButton("Horizontal")){
            AudioManager.instance.PlayAudio(AudioManager.instance.walkPlayer);
        }
    }

    private void FixedUpdate(){

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        if(sePuedeMover)
        {
            Mover(movimientoHorizontak * Time.fixedDeltaTime, salto);
        }
        
        salto = false;
    }
    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        if(mover > 0 && !mirandoDerecha){
            Girar();
        }
        else if(mover < 0 && mirandoDerecha){
            Girar();
        }
        if(enSuelo && saltar && botonSaltoArriba){
            Saltar();
        }
        if(rb2D.velocity.y < 0 && !enSuelo){
            rb2D.gravityScale = escalaGravedad * multiplicadorGravedad;
        }else{
            rb2D.gravityScale = escalaGravedad;
        }

    }
    public void Saltar(){
        AudioManager.instance.PlayAudio(AudioManager.instance.jumpPlayer);
        enSuelo = false;
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        botonSaltoArriba = false;
        OnJump?.Invoke(this, EventArgs.Empty);
    }
    private void BotonSaltoArriba(){
        if(rb2D.velocity.y>0)
        {
            rb2D.AddForce(Vector2.down * rb2D.velocity.y * (1 - multiplicadorCancelarSalto), ForceMode2D.Impulse);
        }
        botonSaltoArriba = true;
        salto= false;
    }
    public void Rebote(Vector2 puntoGolpe)
    {
       rb2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y); 
    }
    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
    public void OnCollisionEnter2D(Collision2D laCosa)
    {
        
        if(laCosa.gameObject.tag == "DeathZone" ) //si el cuerpo de lacosa que yo choque tiene tag DeathZone
        {
            //Debug.Log("Toco DeathZone");
            Destroy(this.gameObject);
        }
        
        
    }
}
