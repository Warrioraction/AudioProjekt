using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {
   public Slider volumeSlider;
   public Slider MusicSlider;
   public Slider SFXSlider;
    public AudioMixer mixer;
 private void Start()
 {
     // get the source, so you don't have to "Get" it each time
    
     
     // if the volume has been saved before
     if (PlayerPrefs.HasKey("Music")&&PlayerPrefs.HasKey("SFX"))
     {
         // set the volume to saved volume
         MusicSlider.value= PlayerPrefs.GetFloat("Music",0);
         mixer.SetFloat("BackgroundVol", PlayerPrefs.GetFloat("Music",0));
         SFXSlider.value=PlayerPrefs.GetFloat("SFX",0);
         mixer.SetFloat("SFXVol",PlayerPrefs.GetFloat("SFX",0));
     }
 }
    public void SetLevel ()
    {
        //float a = mixer.GetFloat("BackgroundVol");
        mixer.SetFloat("BackgroundVol", volumeSlider.value );
        
    }
    public void Save(){
        PlayerPrefs.SetFloat("Music", MusicSlider.value );
        PlayerPrefs.SetFloat("SFX", SFXSlider.value );
        

    }
    public void Cancel(){
MusicSlider.value= PlayerPrefs.GetFloat("Music",0);
SFXSlider.value=PlayerPrefs.GetFloat("SFX",0);
        
    }
    public void Mute ()
    {
        volumeSlider.value =-80;    }
      public void Max ()
    {
        volumeSlider.value =20;    
    }
            public void SetSFX ()
    {
        // mixer.GetFloat("SFXVol",volumeSlider.value);
        mixer.SetFloat("SFXVol", volumeSlider.value);

    }
    
}