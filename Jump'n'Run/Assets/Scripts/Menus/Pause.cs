using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
public static bool isGamePaused=false;
[SerializeField] GameObject pauseMenu;    // Update is called once per frame
[SerializeField] GameObject pauseMenuOff;  
 public GameObject Settings;
public GameObject Help;  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused){
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }
    public  void  ResumeGame(){
        pauseMenuOff.SetActive(true);

        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        isGamePaused=false;
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        pauseMenuOff.SetActive(false);
         Help.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused=true;
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
        public void HomeButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
       Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
