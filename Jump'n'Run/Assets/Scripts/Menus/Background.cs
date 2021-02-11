using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


// public class Background : MonoBehaviour
// {
// public int setting=1;
//  void Awake() {
//      if(setting==1)
//      DontDestroyOnLoad(transform.gameObject);
     
//  }
//  public void Stopthemusic(){

//      Destroy(transform.gameObject);
//  }
// }

public class Background : MonoBehaviour 
{
     public AudioMixer mixer;
    private static Background _instance;
 
    public static Background instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Background>();
 
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }
 
            return _instance;
        }
    }
    void Start(){
 if (PlayerPrefs.HasKey("Music")&&PlayerPrefs.HasKey("SFX"))
     {
         // set the volume to saved volume
         mixer.SetFloat("BackgroundVol", PlayerPrefs.GetFloat("Music",0));
         mixer.SetFloat("SFXVol",PlayerPrefs.GetFloat("SFX",0));
     }
}

void Update(){
     if (PlayerPrefs.HasKey("Music")&&PlayerPrefs.HasKey("SFX"))
     {
         // set the volume to saved volume
         mixer.SetFloat("BackgroundVol", PlayerPrefs.GetFloat("Music",0));
         mixer.SetFloat("SFXVol",PlayerPrefs.GetFloat("SFX",0));
     }


    if (( SceneManager.GetActiveScene().buildIndex!=1)&&( SceneManager.GetActiveScene().buildIndex!=0))
    Destroy(this.gameObject);
}
    
 
    void Awake() 
    {
        if(_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if(this != _instance)
                Destroy(this.gameObject);
        }
    }
 
  public void Stopthemusic(){

     GetComponent<AudioSource>().Stop();
  }
    public void Play()
    {
        //Play some audio!
    }
}