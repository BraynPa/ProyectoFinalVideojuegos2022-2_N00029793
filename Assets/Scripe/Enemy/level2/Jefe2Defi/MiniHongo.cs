using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniHongo : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    [SerializeField]private Transform controladorBala;
    [SerializeField] private GameObject bala;
    [SerializeField] private float speed;
    private float timer = 0;
    private bool contar = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Timer();
        StartTimer();
        if(timer > 1){
            animator.SetTrigger("Run");
            rb2D.velocity = new Vector2(speed,rb2D.velocity.y);
            if(timer > 3f){
                animator.SetTrigger("Attack");
                rb2D.velocity = new Vector2(0,rb2D.velocity.y);
                ResetTimer();
            }
        }
    }
    public void Bala(){
        Instantiate(bala, controladorBala.position, controladorBala.rotation);
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
}
