using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthCnt : MonoBehaviour
{
    public GameObject Heart1;
    SpriteRenderer render;
    private PlayerController chamgo;

    private void Start()
    {
        chamgo = FindObjectOfType<PlayerController>();
        render = GetComponent<SpriteRenderer>();
        Alpha255();
    }
    //player가 파괴되지 않고 씬을 이동하기 때문에 따로 생성함
    //알파값 조절하여 사라지는것처럼 보이게 함

    private void Alpha255()
      {
         render.color = new Color32(255, 255, 255, 255);
      }
    
     private void Alpha0()
      {
         render.color = new Color32(255, 255, 255, 0);
      }

    private void Update()
    {
        switch (chamgo.Health)
        {
            case 3:
                Alpha255();
                break;
            case 2:
                Alpha255();
                break;
            case 1:
                Alpha255();
                break;
            case 0:
                Alpha0();
                break;
        }
    }
}
