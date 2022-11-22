using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.level1Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
