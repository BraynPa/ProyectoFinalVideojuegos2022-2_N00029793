using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraNivel2_2 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera myVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera myVirtualCamera2;
    void Start()
    {
        myVirtualCamera.gameObject.SetActive(false);
        myVirtualCamera2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")){
           myVirtualCamera2.gameObject.SetActive(false);
           myVirtualCamera.gameObject.SetActive(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
           myVirtualCamera.gameObject.SetActive(false);
           myVirtualCamera2.gameObject.SetActive(true);
        }
    }
}
