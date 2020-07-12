using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sad_monkey_quest_control : MonoBehaviour
{
  
    private PlayerStats quest_chamgo;
    private PlayerController questIs;

    public int chamgo_CountValue;
    public bool isFinished;

    void Update()
    {
        quest_chamgo = FindObjectOfType<PlayerStats>();
        questIs = FindObjectOfType<PlayerController>();

        chamgo_CountValue = quest_chamgo.flycount;
        isFinished = questIs.quest4Finished;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            if (isFinished == false)
            {
                GameObject.FindWithTag("dial4").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
            if (chamgo_CountValue >= 5)
            {
                GameObject.FindWithTag("dial4_finish").GetComponent<dialogue_trigger>().TriggerDialogue();
                quest_complete();
            }
            if (chamgo_CountValue >= 5 && isFinished == true)
            {
                GameObject.FindWithTag("dial4_idle").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
        }
    }

    void quest_complete()
    {
        questIs.quest4Finished = true;
    }
}
