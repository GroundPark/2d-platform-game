using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Snake_movement : MonoBehaviour
{
    static public Enemy_Snake_movement instance;

    public int snake_hp = 4;

    public float movePower = 1f;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    bool IsTracing = false;
    GameObject traceTarget;
    //0:idle , 1:left 2:Right
    SpriteRenderer rend;


    private float stunTime;
    public float startStunTime;

    public int damage = 1;

    //public GameObject arrow_hit_effect;

    void Death()
    {
        Destroy(this.gameObject);
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

    public void Snake_Damage()
    {
        stunTime = startStunTime;
        snake_hp--;

        if (snake_hp <= 0)
        {
            StartCoroutine("FadeOut");
            Invoke("Death", 1.5f);

        }
    }
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine("ChangeMovement");
    }

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

    //랜덤으로 자동으로 움직이게 애니메이션, 코루틴 설정

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }

        //if (other.gameObject.tag == "Arrow" && snake_hp > 0)
        //{
        //    Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
        //    Invoke("Snake_Damage", 0.001f);
        //}

        //if (other.gameObject.tag == "Sword" && snake_hp > 0)
        //{
        //    Instantiate(arrow_hit_effect, new Vector2(transform.position.x, transform.position.y - 0.03f), Quaternion.identity);
        //    Invoke("Snake_Damage", 0.001f);
        //}
    }
    //col에닿는 tag로 플레이어 확인
    // 자동으로 움직이던 코루틴 종료

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTracing = true;
            animator.SetBool("isMoving", true);
        }
    }
    //플레이어가 collider 2d 범위안에 있을때 행동

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }
    //플레이어가 collier2d 범위 밖으로 나가면 자동으로 움직이는 코루틴 재시작

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dir = "";

        if (IsTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
            {
                dir = "Left";
            }
            else if (playerPos.x > transform.position.x)
            {
                dir = "Right";
            }
        }
        // 벡터초기화, 플레이어위치 x값 비교하여 방향 판별
        else
        {
            if (movementFlag == 1)
                dir = "Left";
            else if (movementFlag == 2)
                dir = "Right";
        }
        // 판별과 추적
        if (dir == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (dir == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
        //flip메소드 추가 및 속도 설정
    }


}




