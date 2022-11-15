using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuReinicio : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private CombatePlayer combateJugador;

    private void Start()
    {
        combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatePlayer>();
        combateJugador.MuerteJugador += AbrirMenu; 

    }
    private void AbrirMenu(object sender, EventArgs e) {
        menu.SetActive(true);
    }
    public void Reiniciar()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigo"), false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
