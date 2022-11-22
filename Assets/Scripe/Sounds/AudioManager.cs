using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer, efectosMixer;

    public AudioSource disparoPlayer, damagePlayer, espadaPlayer, jumpPlayer, walkPlayer, explosion1, explosion2, enemigo3Attack, enemigoDamage, enemigoDies, espadaJefe3, espadaJefe3Cae, openCofre, mounstroAtaca, levelComplete, gameOver, level1Back, level2Back, level3Back, jefelevel2Back, enemigoMuere, text, button, palanca, enemigoPatada, habilidadAgua, impactoGolpe; 
    public static AudioManager instance;
    [Range(-80,10)]
    public float masterVol, efectoVol;
    public Slider masterSlider, efectoSlider;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    void Start()
    {
        masterSlider.value = masterVol;
        efectoSlider.value = efectoVol;

        masterSlider.minValue = -80;
        masterSlider.maxValue = 10;
        efectoSlider.minValue = -80;
        efectoSlider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectVolume();

    }
    
    public void MasterVolume(){
        masterMixer.SetFloat("MasterVolumen",masterSlider.value);
    }
    public void EffectVolume(){
        efectosMixer.SetFloat("EfectoVolumen",efectoSlider.value);
    }
    public void PlayAudio(AudioSource audio){
        audio.Play();
    }

}
