using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Jefe2OfStatus
{
    IDLE,
    ATAQUEPUNO2,
    ATTACKPUNO,
    CREATEMINIHONGO,
    CREATEPINCHOS,
    DEATH
}


public class Jefe2Of : MonoBehaviour, IDaño
{
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject Two;
    [SerializeField] private GameObject NextLevel;
    [SerializeField] private GameObject MiniHongo;
    [SerializeField] private Transform controladorMiniHongo;
    [Header("Vida")]

    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;
    private bool isDeath;

    public Jefe2OfStatus status;
    Animator anim;
    public float statusCh;
    void Start()
    {
        status = Jefe2OfStatus.IDLE;
        anim = GetComponent<Animator>();
        isDeath = false;
        StartCoroutine(Jefe2OfStatuses());
    }
    public void ActivePinchos()
    {
        one.SetActive(true);
        Two.SetActive(true);
    }
    public void NoActivePinchos()
    {
        one.SetActive(false);
        Two.SetActive(false);
    }
    public void CreateMiniHongo(){
        Instantiate(MiniHongo, controladorMiniHongo.position, Quaternion.identity);
    }
    IEnumerator Jefe2OfStatuses()
    {
        if(!isDeath){
            var randomAttack = Random.Range(0,5);
        yield return new WaitForSeconds(statusCh);
        switch (randomAttack)
        {
            case 0:
                status = Jefe2OfStatus.IDLE;
                break;
            case 1:
                status = Jefe2OfStatus.ATAQUEPUNO2;
                break;
            case 2:
                status = Jefe2OfStatus.ATTACKPUNO;
                break;
            case 3:
                status = Jefe2OfStatus.CREATEMINIHONGO;
                break;
            case 4:
                status = Jefe2OfStatus.CREATEPINCHOS;
                break;
            default:
                break;
        }
        StatusChanger();
        }
    }

    public void StatusChanger()
    {
        switch(status)
        {
            case Jefe2OfStatus.IDLE:
                anim.SetTrigger("IDLE");
                StartCoroutine(Jefe2OfStatuses());
                break;
            case Jefe2OfStatus.ATAQUEPUNO2:
                AudioManager.instance.PlayAudio(AudioManager.instance.enemigoPatada);
                anim.SetTrigger("COMBO2");
                StartCoroutine(Jefe2OfStatuses());
                break;
            case Jefe2OfStatus.ATTACKPUNO:
                AudioManager.instance.PlayAudio(AudioManager.instance.enemigoPatada);
                anim.SetTrigger("COMBO1");
                StartCoroutine(Jefe2OfStatuses());
                break;
            case Jefe2OfStatus.CREATEMINIHONGO:
                anim.SetTrigger("CREATEMINIHONGO");
                StartCoroutine(Jefe2OfStatuses());
                break;
            case Jefe2OfStatus.CREATEPINCHOS:
                anim.SetTrigger("CREATEPINCHOS");
                StartCoroutine(Jefe2OfStatuses());
                break;
            default:
                break;
        }
    }
    public void TomarDaño(float daño)
    {
        ControladorJuego.totalDaño += daño;
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0)
        {
            anim.SetTrigger("DEATH");
        }
    }
    private void Muerte()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.enemigoDies);
        NextLevel.SetActive(true);
        isDeath = true;
    }
}
