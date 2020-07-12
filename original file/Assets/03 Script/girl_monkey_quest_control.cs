using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_monkey_quest_control : MonoBehaviour
{
    public int ReduceRockValue = -20;
    public int ReduceWoodValue = -20;
    //public bool isFinished = false;

    private PlayerStats quest_chamgo;
    private PlayerController questIs;

    public int chamgo_RockValue;
    public int chamgo_WoodValue;
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

        chamgo_RockValue = quest_chamgo.RocksCollected;
        chamgo_WoodValue = quest_chamgo.WoodsCollected;
        isFinished = questIs.quest3Finished;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            if (isFinished == false)
            {
                GameObject.FindWithTag("dial3").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
            if (chamgo_RockValue >= 20 && chamgo_WoodValue >= 20)
            {
                GameObject.FindWithTag("dial3_finish").GetComponent<dialogue_trigger>().TriggerDialogue();
                quest_complete();
            }
            if (chamgo_RockValue >= 0 && isFinished == true)
            {
                GameObject.FindWithTag("dial3_idle").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
        }
    }

    void quest_complete()
    {
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.CollectRock(this.ReduceRockValue);
        stats.CollectWood(this.ReduceWoodValue);
        //isFinished = true;
        questIs.quest3Finished = true;
    }
}
