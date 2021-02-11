using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AmbienceSound : MonoBehaviour
{
    private AudioSource _audioSource;
    
    public AudioMixerGroup _levelAtmosphere;
    
    public AudioClip[] forestClips;
    public AudioClip[] swampClips;
    public AudioClip[] caveClips;

    private string _sceneName;
    private int _clipIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _sceneName = SceneManager.GetActiveScene().name;
        
        if (_sceneName == "ForestLevel")
        {
            if (forestClips.Length > 0)
            {
                StartCoroutine(PlaySoundForest());
            }
        }
        else if (_sceneName == "SwampLevel")
        {
            if (swampClips.Length > 0)
            {
                StartCoroutine(PlaySoundSwamp()); 
            }
        } 
        else if (_sceneName == "CaveLevel1")
        {
            if (caveClips.Length > 0)
            {
                StartCoroutine(PlaySoundCave());
            }
        }
    }
    
    IEnumerator PlaySoundForest()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        _clipIndex = Random.Range(0, forestClips.Length - 1);
        _audioSource.PlayOneShot(forestClips[_clipIndex], 1f);

        yield return new WaitForSeconds(forestClips[_clipIndex].length);
        StartCoroutine(PlaySoundForest());
    }
    
    IEnumerator PlaySoundSwamp()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        _clipIndex = Random.Range(0, swampClips.Length - 1);
        _audioSource.PlayOneShot(swampClips[_clipIndex], 1f);

        yield return new WaitForSeconds(swampClips[_clipIndex].length);
        StartCoroutine(PlaySoundSwamp());
    }
    
    IEnumerator PlaySoundCave()
    {
        yield return new WaitForSeconds(Random.Range(4f, 7f));

        _clipIndex = Random.Range(0, caveClips.Length - 1);
        _audioSource.PlayOneShot(caveClips[_clipIndex], 1f);

        yield return new WaitForSeconds(caveClips[_clipIndex].length);
        StartCoroutine(PlaySoundCave());
    }
}
