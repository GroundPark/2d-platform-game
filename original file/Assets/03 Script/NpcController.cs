using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public GameObject Questalarm;
    bool IsPopup = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsPopup == false)
        {
            IsPopup = true;
            Questalarm.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(Questalarm.gameObject);
        //Questalarm.gameObject.SetActive(false);
    }
    
}
