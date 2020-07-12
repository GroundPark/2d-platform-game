using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_popup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("maindial").GetComponent<dialogue_trigger>().TriggerDialogue();
        }
    }

}

