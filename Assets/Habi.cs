using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habi : MonoBehaviour
{
    [SerializeField] private GameObject Dos;

    public void ActiveSuelo(){
        Dos.SetActive(false);
    }

}
