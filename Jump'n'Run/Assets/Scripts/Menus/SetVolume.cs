using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {
   public Slider volumeSlider;
    public AudioMixer mixer;

    public void SetLevel ()
    {
        mixer.SetFloat("BackgroundVol", volumeSlider.value * 20);
    }
    public void Mute ()
    {
        volumeSlider.value =-1;    }
      public void Max ()
    {
        volumeSlider.value =1;    }
            public void SetSFX ()
    {
        mixer.SetFloat("SFXVol", volumeSlider.value * 20);
    }
    
}