using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cave_level_prev : MonoBehaviour
{
    private PlayerController thePlayer;
    //PlayerController의 currentMapname 변수 참고용

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.currentMapName == "Island_esc2" && thePlayer.prev_level_check == "Cave")
        {
            thePlayer.transform.position = this.transform.position;
        }


    }
}