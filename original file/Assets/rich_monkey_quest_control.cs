using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rich_monkey_quest_control : MonoBehaviour
{
    public int ReduceCoinValue = -5;
    //public bool isFinished = false;

    private PlayerStats quest_chamgo;
    private PlayerController questIs;

    public int chamgo_CoinValue;
    public bool isFinished;
    

    //void Start()
    //{
    //    quest_chamgo = FindObjectOfType<PlayerStats>();
    //    chamgo_keyValue = quest_chamgo.KeysCollected;
    //}

    void Update()
    {
        quest_chamgo = FindObjectOfType<PlayerStats>();
        questIs = FindObjectOfType<PlayerController>();

        chamgo_CoinValue = quest_chamgo.coinsCollected;
        isFinished = questIs.quest2Finished;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            if (isFinished == false)
            {
                GameObject.FindWithTag("dial1").GetComponent<dialogue_trigger>().TriggerDialogue();

            }
            if (chamgo_CoinValue >= 5)
            {
                GameObject.FindWithTag("dial1_finish").GetComponent<dialogue_trigger>().TriggerDialogue();
                quest_complete();
            }
            if (chamgo_CoinValue >= 0 && isFinished == true)
            {
                GameObject.FindWithTag("dial1_idle").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
        }
    }

    void quest_complete()
    {
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.CollectCoin(this.ReduceCoinValue);
        //isFinished = true;
        questIs.quest2Finished = true;
    }
}
