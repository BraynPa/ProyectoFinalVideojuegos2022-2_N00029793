using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasExtraController : MonoBehaviour
{
    [SerializeField] private GameObject vida4;
    private CombatePlayer combatePlayer;
    private void Start(){
        
        combatePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatePlayer>();
    }
    private void Update(){
        if(combatePlayer.GetVida()<=300){
            vida4.SetActive(false);
        }else if(combatePlayer.GetVida()>=300){
            vida4.SetActive(true);
        }
    }

}
