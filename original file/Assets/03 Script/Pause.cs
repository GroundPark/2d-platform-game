using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;

    public static bool IsPaused = false;
    
    

    void Start()
    {
        PauseUI.SetActive(false);       
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (IsPaused)
            {
                Resume_Game();
            }
            else
            {
                Pause_Game();
            }
        }
           
       

        }

    public void Resume_Game()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        
    }


    void Pause_Game()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

 
    public void MainMenu()
    {

        PauseUI.SetActive(false);
        GameObject.Find("Player_Idle1").GetComponent<PlayerController>().Self_Destroy();
        GameObject.Find("Canvas").GetComponent<Canvas_control>().Self_Destroy_UI();
        
        SceneManager.LoadScene("Intro");

    }

}
