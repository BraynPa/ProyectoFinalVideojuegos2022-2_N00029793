using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static bool Col2 = false;
    public static bool Col3 = false;
    public static bool Friend = false;
    public static bool estadisticaItem = false;
    public static float totalDaño;
    public static float vecesMuerto;
    public static int escena = 1;
    void Start()
    {
        
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
}
