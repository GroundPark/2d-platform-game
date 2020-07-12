using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPick : MonoBehaviour
{
    public int coinValue = 1;           

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats stats = collider.gameObject.GetComponent<PlayerStats>();
            stats.CollectCoin(this.coinValue);

            Destroy(this.gameObject);
        }

        //playerstats의 collectCoin 함수 호출, 값 저장
    }
 
}
