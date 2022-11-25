using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicioEscena : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(){
        StartCoroutine(CambiarEscena());
    }
    IEnumerator CambiarEscena(){
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

    }
}
