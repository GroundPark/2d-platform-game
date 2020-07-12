using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPick : MonoBehaviour
{
    public int KeyValue = 1;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats stats = collider.gameObject.GetComponent<PlayerStats>();
            stats.CollectKey(this.KeyValue);
            Destroy(this.gameObject);
        }

        //playerstats의 collectCoin 함수 호출, 값 저장
    }
}
