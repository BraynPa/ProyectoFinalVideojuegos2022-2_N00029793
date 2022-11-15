using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public GameObject personaje; //Objeto a Seguir
    private Vector3 posicionRelativa;

    // Use this for initialization
    void Start () {

    posicionRelativa = transform.position - personaje.transform.position;

    }

    // Update is called once per frame
    void LateUpdate () {

    transform.position = personaje.transform.position + posicionRelativa;

    }
}
