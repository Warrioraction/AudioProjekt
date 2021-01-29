using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Settings : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Help;

    // Start is called before the first frame update
    void Start()
    {
        SettingsButton();
    }

    public void BackSettingsButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
     

    public void HelpButton()
    {
        // Show Credits Menu
        Settings.SetActive(false);
        Help.SetActive(true);
    }

    public void SettingsButton()
    {
        // Show Main Menu
        Settings.SetActive(true);
        Help.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}