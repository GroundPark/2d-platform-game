using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_damage_col : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerController hp_stats = collision.gameObject.GetComponent<PlayerController>();
            hp_stats.TakeDamage(this.damage);
        }
    }
}