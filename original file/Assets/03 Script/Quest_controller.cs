using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_controller : MonoBehaviour
{
    
    

    

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
        {

            
            GameObject.FindWithTag("dial1").GetComponent<dialogue_trigger>().TriggerDialogue();

            //Debug.Log("반응합니다");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(Questalarm.gameObject);
        //Questalarm.gameObject.SetActive(false);
    }



}
