using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habi : MonoBehaviour
{
    [SerializeField] private GameObject Dos;
    [SerializeField] private GameObject Suelo;
    [SerializeField] private GameObject SueloCol;

    public void ActiveSuelo(){
        Dos.SetActive(false);
        Suelo.SetActive(false);
        SueloCol.SetActive(false);
    }

}
