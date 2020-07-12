using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1startpoint : MonoBehaviour
{
    public string startPoint;
    //플레이어 시작위치
    private PlayerController thePlayer;
    //PlayerController의 currentMapname 변수 참고용

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        //PlayerController 오브젝트 반환
        if (startPoint == thePlayer.currentMapName)
        { 
            thePlayer.transform.position = this.transform.position;
        }
        // level의 start point 위치값으로 플레이어 이동
    }
}
