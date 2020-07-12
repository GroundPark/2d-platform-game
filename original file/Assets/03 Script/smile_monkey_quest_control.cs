using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smile_monkey_quest_control : MonoBehaviour
{
    public int ReduceKeyValue = -1;
    //public bool isFinished = false;

    private PlayerStats quest_chamgo;
    private PlayerController questIs;

    public int chamgo_keyValue;
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

        chamgo_keyValue = quest_chamgo.KeysCollected;
        isFinished = questIs.quest1Finished;
    }

    void OnTriggerStay2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            if (isFinished == false)
            {
                GameObject.FindWithTag("dial2").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
            if (chamgo_keyValue == 1)
            {
                GameObject.FindWithTag("dial2_finish").GetComponent<dialogue_trigger>().TriggerDialogue();
                quest_complete();
            }
            if (isFinished == true)
            {
                GameObject.FindWithTag("dial2_idle").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
        }
    }

    void quest_complete()
    {
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.CollectKey(this.ReduceKeyValue);
        //isFinished = true;
        questIs.quest1Finished = true;
    }
}
