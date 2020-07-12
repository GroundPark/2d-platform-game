using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int Rock_hp = 2;
    SpriteRenderer rend;

    public GameObject hammer_hit_effect;

    public int RockValue = 1;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
     
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.2f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }

 

    public void Rock_Damage()
    {
        Rock_hp--;
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.CollectRock(this.RockValue);

        if (Rock_hp == 0)
        {
            StartCoroutine("FadeOut");
            Invoke("Death", 0.7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hammer" && Rock_hp > 0)
        {
            Instantiate(hammer_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
            Invoke("Rock_Damage", 0.001f);
        }
    }


}
