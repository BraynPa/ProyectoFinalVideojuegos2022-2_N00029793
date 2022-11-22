using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatePlayer : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] private float tiempoPerdidaControl;
    private VidasController combateJugador;
    private MovePlayer MovimientoJugador;
    private Animator animator;
    public event EventHandler MuerteJugador;
    private Rigidbody2D rb2D;
    private Vector3 checkpoint;

    private void Start(){
        MovimientoJugador = GetComponent<MovePlayer>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        combateJugador = GameObject.FindGameObjectWithTag("ControlarVidas").GetComponent<VidasController>();
    }
    public void TomarDaño(float daño, float i, float f, float t)
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.damagePlayer);
        EfectoDaño(i,f,t);
        vida -= daño;
        if(vida>0)
        {
            animator.SetTrigger("Perder");
        }
        if (vida <= 0)
        {   
            combateJugador.Vida1();
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muerte");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigo"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Zorro"), true);
        }else if(vida <= 100){
            combateJugador.Vida2();
        }else if(vida <= 200){
            combateJugador.Vida3();
        }
    }
    public float GetVida(){
        float prueba = vida;
        return prueba;
    }
    
    public void TomarDaño(float daño, Vector2 posicion, float i, float f, float t){
        AudioManager.instance.PlayAudio(AudioManager.instance.damagePlayer);
        EfectoDaño(i,f,t);
        vida -= daño;
        if(vida>0)
        {
            animator.SetTrigger("Perder");
            StartCoroutine(PerderControl());
            StartCoroutine(DesactivarColision());
            MovimientoJugador.Rebote(posicion);
        }
        if (vida <= 0)
        {   
            combateJugador.Vida1();
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muerte");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigo"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Zorro"), true);

        }else if(vida <= 100){
            combateJugador.Vida2();
        }else if(vida <= 200){
            combateJugador.Vida3();
        }
    }
    public void TomarDaño(float i, float f, float t){
        EfectoDaño(i,f,t);
    }
    private void EfectoDaño(float i, float f, float t){
        CineMCmaraMovimiento.Instance.MoverCamara(i,f,t);
    }
    private void Muerte()
    {
        Destroy(gameObject);
        combateJugador.VidaRestore();
    }
    
    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(7,8, true);
        Physics2D.IgnoreLayerCollision(7,9, true);
        yield return new WaitForSeconds(tiempoPerdidaControl); 
        Physics2D.IgnoreLayerCollision(7,8, false);
        Physics2D.IgnoreLayerCollision(7,9, false);
    }
    private IEnumerator PerderControl(){
        MovimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        MovimientoJugador.sePuedeMover = true;
    }
    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this,EventArgs.Empty);
    }
}
