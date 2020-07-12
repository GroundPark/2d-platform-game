using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recover_hp : MonoBehaviour
{

    int Healing = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerController heal = collider.gameObject.GetComponent<PlayerController>();
            heal.RestoreHp(this.Healing);
            Destroy(this.gameObject);
        }
        //healing 값만큼 치료
    }
}