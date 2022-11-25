using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class estadistica : MonoBehaviour
{
    [SerializeField] private Text danio, itemText, muerte;
    private star star1, star2, star3;
    private int item;
    void Start()
    {
        ControladorJuego.estadisticaItem = true;
        item = 1;

        star1 = GameObject.FindGameObjectWithTag("star1").GetComponent<star>();
        star2 = GameObject.FindGameObjectWithTag("star2").GetComponent<star>();
        star3 = GameObject.FindGameObjectWithTag("star3").GetComponent<star>();
        if(ControladorJuego.Col2){
            item += 1;
        }
        if(ControladorJuego.Col3){
            item += 1;
        }
        
    }

    void Update()
    {
        danio.text = ControladorJuego.totalDaño.ToString();
        muerte.text = ControladorJuego.vecesMuerto.ToString();
        
        itemText.text = item.ToString();
            
            
            
       if(ControladorJuego.totalDaño >= 7500){
            if(ControladorJuego.vecesMuerto <= 7){
                if(item == 3){
                    star1.setActive();
                    star2.setActive();
                    star3.setActive();
                }else if(item == 2){
                    star1.setActive();
                    star2.setActive();
                }else{
                    star1.setActive();
                    star2.setActive();
                }
            }else if(ControladorJuego.vecesMuerto > 7 && ControladorJuego.vecesMuerto <= 12){
                if(item == 3){
                    star1.setActive();
                    star2.setActive();
                }else if(item == 2){
                    star1.setActive();
                    star2.setActive();
                }else{
                    star1.setActive();
                    star2.setActive();
                }

            }else if(ControladorJuego.vecesMuerto > 12){
                if(item == 3){
                    star1.setActive();
                }else if(item == 2){
                    star1.setActive();
                }else{
                    star1.setActive();
                }

            }
        }
        if(ControladorJuego.totalDaño < 7500 && ControladorJuego.totalDaño >= 7370){
            if(ControladorJuego.vecesMuerto <= 7){
                if(item == 3){
                    star1.setActive();
                    star2.setActive();
                }else if(item == 2){
                    star1.setActive();
                    star2.setActive();
                }else{
                    star1.setActive();
                    star2.setActive();
                }
            }else if(ControladorJuego.vecesMuerto > 7 && ControladorJuego.vecesMuerto <= 12){
                if(item == 3){
                    star1.setActive();
                    star2.setActive();
                }else if(item == 2){
                    star1.setActive();
                }else{
                    star1.setActive();
                }

            }
        }
        if(ControladorJuego.totalDaño < 7370){
            if(ControladorJuego.vecesMuerto <= 7){
                if(item == 3){
                    star1.setActive();
                    star2.setActive();
                }else if(item == 2){
                    star1.setActive();
                    star2.setActive();
                }else{
                    star1.setActive();

                }
            }else if(ControladorJuego.vecesMuerto > 7 && ControladorJuego.vecesMuerto <= 12){
                if(item == 3){
                    star2.setActive();
                }else if(item == 2){
                    star2.setActive();
                }

            }

        }
        

    }
    public void inicio(){
        SceneManager.LoadScene(0);
    }
}
