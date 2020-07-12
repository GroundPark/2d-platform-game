using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCnt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
         {
            Destroy(gameObject);
         }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
 //col이 wall,Enemy 등 맞아서 멈추는 느낌드는곳은 화살이 없어지도록 이것을 설정
}
