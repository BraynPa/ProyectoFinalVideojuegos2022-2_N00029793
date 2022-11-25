using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendActive : MonoBehaviour
{
    [SerializeField] private GameObject friend;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ControladorJuego.Friend){
            friend.SetActive(true);
        }else{
            friend.SetActive(false);
        }
        
    }
}
