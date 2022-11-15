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

    [Header("Animacion")]

    private Animator animator;

    public event EventHandler OnJump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontak = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontak));
        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if(Input.GetButtonDown("Jump")){
            salto = true;
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
        if(enSuelo && saltar){
            Saltar();
        }

    }
    public void Saltar(){
        enSuelo = false;
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        OnJump?.Invoke(this, EventArgs.Empty);
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
