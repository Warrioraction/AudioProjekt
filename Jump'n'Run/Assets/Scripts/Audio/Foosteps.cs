using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foosteps : MonoBehaviour
{
    
    private AudioSource _audioSource;
    private AudioClip _previousClip;
    
    public AudioClip[] stoneClips;
    public AudioClip[] grassClips;
    public AudioClip[] woodClips;
    public AudioClip[] crystalClips;
    
    private RaycastHit2D hit;
    
    private string _sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _sceneName = SceneManager.GetActiveScene().name;
    }

    private AudioClip GetRandomClip(AudioClip[] availableClips)
    {
        AudioClip[] clipsCopy = availableClips;
        clipsCopy = clipsCopy.Where(val => val != _previousClip).ToArray();
        _previousClip = clipsCopy[UnityEngine.Random.Range(0, clipsCopy.Length)];
        return _previousClip;
    }
    
    public void Step()
    {
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 5f);
        Debug.Log(hit.transform.gameObject.tag);
        
        if (hit.transform.gameObject.CompareTag("Leaves") || hit.transform.gameObject.CompareTag("GrassPlatform"))
        {
            _audioSource.PlayOneShot(GetRandomClip(grassClips));
        }
        
        else if (hit.transform.gameObject.CompareTag("Wood"))
        {
            _audioSource.PlayOneShot(GetRandomClip(woodClips));
        }
        
        else if (hit.transform.gameObject.CompareTag("Stone") || hit.transform.gameObject.CompareTag("StonePlatform"))
        {
            _audioSource.PlayOneShot(GetRandomClip(stoneClips));
        }

        else if (hit.transform.gameObject.CompareTag("CrystalPlatform"))
        {
            _audioSource.PlayOneShot(GetRandomClip(crystalClips));
        }
    }
}
