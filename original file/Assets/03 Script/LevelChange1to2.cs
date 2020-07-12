using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange1to2 : MonoBehaviour
{
    public string transferMapName;
    private PlayerController thePlayer;
    //PlayerController의 currentMapname 변수 참고용

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        //PlayerController 반환
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name == "Player_Idle1")
        {
            
            thePlayer.currentMapName = transferMapName;
            
          
            if (thePlayer.currentMapName == "Island_esc1")
            {
                thePlayer.prev_level_check = "prev_town";
            }
            if (thePlayer.currentMapName == "Island_esc3")
            {
                thePlayer.prev_level_check = "Mushroom";
            }
            if (thePlayer.currentMapName == "Island_esc4")
            {
                thePlayer.prev_level_check = "Cave";
            }

            SceneManager.LoadScene(transferMapName);
            //플레이어가 충돌 트리거 시에 설정해놓은 씬 로드

        }
    }
}
