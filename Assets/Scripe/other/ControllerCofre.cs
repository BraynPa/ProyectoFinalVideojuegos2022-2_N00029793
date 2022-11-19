using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCofre : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Text2;
    [SerializeField] private GameObject Friend;
    [SerializeField] private GameObject Friend2;
    private Animator animator;
    private bool pressV;
    void Start()
    {
        pressV = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.V)){
            Text.SetActive(false);
            pressV = true;
            animator.SetTrigger("isopen");  
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !pressV){
           Text.SetActive(true);
        }
        if(collision.gameObject.CompareTag("Player") && pressV){
           Text.SetActive(false);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            Text.SetActive(false);
        }
    }
    public void activeFriend(){
        Text2.SetActive(true);
        Friend.SetActive(true);
        Friend2.SetActive(true);
    }
}
