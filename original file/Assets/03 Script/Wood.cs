using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int Wood_hp = 2;
    SpriteRenderer rend;


    public int WoodValue = 1;

    public GameObject hammer_hit_effect;

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





    public void Wood_Damage()
    {
        Wood_hp--;
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.CollectWood(this.WoodValue);

        if (Wood_hp == 0)
        {
            StartCoroutine("FadeOut");
            Invoke("Death", 0.7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hammer" && Wood_hp > 0)
        {
            Instantiate(hammer_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
            Invoke("Wood_Damage", 0.001f);
        }
    }


}
