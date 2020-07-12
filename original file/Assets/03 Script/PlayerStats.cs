using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public Text KeyText;
    public Text CoinText;
    public Text RockText;
    public Text WoodText;

    public int KeysCollected = 0;
    public int coinsCollected = 0;
    public int RocksCollected = 0;
    public int WoodsCollected = 0;

    public int flycount = 0;

    public void flycounter(int countValue)
    {
        this.flycount = this.flycount + countValue;
    }

    public void CollectCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;
        
        CoinText.text = "" + coinsCollected;
    }

    public void CollectKey(int KeyValue)
    {
        this.KeysCollected = this.KeysCollected + KeyValue;
        KeyText.text = "" + KeysCollected;
    }

    public void CollectRock(int RockValue)
    {
        this.RocksCollected = this.RocksCollected + RockValue;
        RockText.text = "" + RocksCollected;
    }

    public void CollectWood(int WoodValue)
    {
        this.WoodsCollected = this.WoodsCollected + WoodValue;
        WoodText.text = "" + WoodsCollected;
    }
    //int형 인자받는데 coinsCollected에 더하게 함





}
