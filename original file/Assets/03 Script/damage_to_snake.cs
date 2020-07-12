using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_to_snake : MonoBehaviour
{
    public GameObject arrow_hit_effect;

    private Enemy_Snake_movement Snake_chamgo;
    public int chamgo_snake_hp;

    //instance 참고용 

    void Start()
    {
        Snake_chamgo = FindObjectOfType<Enemy_Snake_movement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        chamgo_snake_hp = Snake_chamgo.snake_hp;

        if (other.gameObject.tag == "Arrow" && chamgo_snake_hp > 0)
        {
            Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);

            Snake_chamgo.Snake_Damage();
        }

        if (other.gameObject.tag == "Sword" && chamgo_snake_hp > 0)
        {
            Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
            Snake_chamgo.Snake_Damage();
            //Invoke("Snake_Damage", 0.001f);
        }
    }



}
