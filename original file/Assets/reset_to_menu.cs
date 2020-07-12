using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset_to_menu : MonoBehaviour
{
 

    public void Quit_UI()
    {

        SceneManager.LoadScene("Intro");

    }
}
