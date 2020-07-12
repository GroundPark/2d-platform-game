using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esc1_startpoint : MonoBehaviour
{
    private PlayerController thePlayer;
    //PlayerController의 currentMapname 변수 참고용

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        if (thePlayer.currentMapName == "" || thePlayer.currentMapName == "Island_esc")
        {
            thePlayer.transform.position = this.transform.position;
        }
    }

}
