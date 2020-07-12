using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_changer_point : MonoBehaviour
{
    private PlayerController thePlayer;
    //PlayerController의 currentMapname 변수 참고용

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.currentMapName == "")
        {
            thePlayer.transform.position = this.transform.position;
        }
        // level의 start point 위치값으로 플레이어 이동
    }

}
