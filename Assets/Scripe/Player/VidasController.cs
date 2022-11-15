using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasController : MonoBehaviour
{
    [SerializeField] private GameObject vida1;
    [SerializeField] private GameObject vida2;
    [SerializeField] private GameObject vida3;
    public void Vida1(){
        vida1.SetActive(false);
    }
    public void Vida2(){
        vida2.SetActive(false);
    }
    public void Vida3(){
        vida3.SetActive(false);
    }
    public void VidaRestore(){
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }
}
