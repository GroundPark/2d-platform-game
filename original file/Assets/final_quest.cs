using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_quest : MonoBehaviour
{
    private PlayerController questIs;

    public bool is1Finished;
    public bool is2Finished;
    public bool is3Finished;
    public bool is4Finished;

    public GameObject Thebulb;
    

    void Update()
    {

        questIs = FindObjectOfType<PlayerController>();

        is1Finished = questIs.quest1Finished;
        is2Finished = questIs.quest2Finished;
        is3Finished = questIs.quest3Finished;
        is4Finished = questIs.quest4Finished;

        if (is1Finished == true && is2Finished == true && is3Finished == true && is4Finished == true)
        {
            Thebulb.gameObject.SetActive(true);
        }
        

    }



        void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {
            if (is1Finished == true && is2Finished == true && is3Finished == true && is4Finished == true)
            {
                GameObject.FindWithTag("dial5").GetComponent<dialogue_trigger>().TriggerDialogue();
            }
        }
    }

}
