using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    private CombatePlayer combatePlayer;
    private Animator animator;
    void Start()
    {
       combatePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatePlayer>(); 
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active(){
        combatePlayer.TomarDaño(2.5f,3,2);
    }
    public void ActiveCaida(){
        animator.SetTrigger("Active");
    }

}
