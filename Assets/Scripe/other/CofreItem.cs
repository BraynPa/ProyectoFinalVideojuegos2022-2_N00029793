using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreItem : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Text2;
    [SerializeField] private GameObject itemCollection;
    private Animator animator;
    private bool pressV;
    private bool cerca;
    void Start()
    {
        pressV = false;
        cerca  = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.V) && cerca){
            Text.SetActive(false);
            pressV = true;
            animator.SetTrigger("isopen");  
        }
    }
    public void OpenCofre(){
        AudioManager.instance.PlayAudio(AudioManager.instance.openCofre);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !pressV){
           Text.SetActive(true);
           cerca = true;
        }
        if(collision.gameObject.CompareTag("Player") && pressV){
           Text.SetActive(false);
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
        itemCollection.SetActive(true);
    }
}
