using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CntroladorJuego : MonoBehaviour
{
   /* public static CntroladorJuego Instance;
    [SerializeField] private GameObject jugador;
    private int indexPuntosControl;

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void Awake()
    {
        Instance = this;
        puntosDeControl = GameObject.FindGameObjectsWithTag("PuntoDeControl");
        indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
        Instantiate(jugador, puntosDeControl[indexPuntosControl].transform.position, Quaternion.identity);
    }
    public void UltimoPuntoControl(GameObject puntoControl){
        for(int i = 0; i < puntosDeControl.Length; i++){
            if(puntosDeControl[i] == puntoControl){
                PlayerPrefs.SetInt("puntosIndex", i);
            }
        }
    }*/
}
