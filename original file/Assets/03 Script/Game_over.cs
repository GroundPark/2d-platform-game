using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    public GameObject QuitUI;

    public void Quit_UI()
    {

        QuitUI.SetActive(false);
        GameObject.Find("Player_Idle1").GetComponent<PlayerController>().Self_Destroy();
        GameObject.Find("Canvas").GetComponent<Canvas_control>().Self_Destroy_UI();

        SceneManager.LoadScene("Intro");

    }
}
