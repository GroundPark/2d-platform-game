using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_trigger : MonoBehaviour
{
    public dialogue Dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogue_manager>().StartDialogue(Dialogue);
    }
    
}
