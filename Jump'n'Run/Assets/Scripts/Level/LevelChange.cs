using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    public Animator fadeAnimator;
    public CharacterController2D player;

    private string _sceneName;
    
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        _sceneName = currentScene.name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        player.disableInput = true;
        player.maxSpeed = 0;
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(4);
        if (_sceneName == "ForestLevel")
        {
            SceneManager.LoadScene("SwampLevel");
        }
        else if (_sceneName == "SwampLevel")
        {
            SceneManager.LoadScene("CaveLevel1");
        }
        else if (_sceneName == "CaveLevel1")
        {
            SceneManager.LoadScene("EndCutscene");
        }
    }
}
