using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsoundLevel3 : MonoBehaviour
{
    
    void Start()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.level3Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
