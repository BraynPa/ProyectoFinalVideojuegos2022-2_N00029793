using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroJefe2 : MonoBehaviour
{
    [Header("Animacion")]

    private Animator animator;
    private CombatePlayer combatePlayer;
    private SpriteRenderer sprite;
    public int sortingOrder = 6;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        combatePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatePlayer>();

    }

    void Update()
    {
        
    }
    public void ChangeOrder(){
        sprite.sortingOrder = sortingOrder;
    }
    public void OnCollisionEnter2D(Collision2D laCosa)
    {
        
        if(laCosa.gameObject.tag == "Suelo") 
        {
            combatePlayer.TomarDaño(2.5f,3,2);
            animator.SetTrigger("Colision");
        }
        
        
    }
}
