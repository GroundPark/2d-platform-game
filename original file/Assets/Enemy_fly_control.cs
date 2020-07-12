using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fly_control : MonoBehaviour
{
    public float movePower = 0.1f;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    //0:idle , 1:left 2:Right
    public int hp = 4;


    private float stunTime;
    public float startStunTime;

    SpriteRenderer rend;

    public GameObject arrow_hit_effect;

    public int damage = 1;


    public int countValue = 1;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovement");
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (stunTime <= 0)
        {
            movePower = 0.1f;
        }
        else
        {
            movePower = 0.0007f;
            stunTime -= Time.deltaTime;
        }
    }



    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Death()
    {
        PlayerStats stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        stats.flycounter(this.countValue);
        Destroy(this.gameObject, 0.1f);
    }



    public void Crab_Damage()
    {
        stunTime = startStunTime;
        hp--;
        if (hp == 0)
        {
            movePower = 0.0007f;
            StartCoroutine("FadeOut");


            Invoke("Death", 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow" && hp > 0)
        {
            Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
            Invoke("Crab_Damage", 0.001f);

        }

        if (collision.tag == "Player")
        {
            PlayerController hp_stats = collision.gameObject.GetComponent<PlayerController>();
            hp_stats.TakeDamage(this.damage);
        }

        if (collision.tag == "Sword" && hp > 0)
        {
            Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
            Invoke("Crab_Damage", 0.001f);
        }

    }



    //데미지 invoke로 지연



    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);
        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");

    }
    //IEnumerator 선언 및 yield return으로 탈출시점설정(waitforseconds 딜레이)
    // 정수 movementFlag (0,1,2) 랜덤값으로 애니메이션 설정

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
        //move에서 왼오른쪽에따른 Flip관리, 속도관리 
    }
}

