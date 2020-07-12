using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_control : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Self_Destroy_UI()
    {
        GameObject.Destroy(gameObject);
    }

}
