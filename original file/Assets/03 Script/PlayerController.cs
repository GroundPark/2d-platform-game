using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;
    //이것들이 적용된 객체들은 (static) 선언된 변수값 공유(바뀔때마다 전부바뀜)
    public string currentMapName;
    //level 관련 스크립트에 있는 Mapname 변수값 저장용

    public bool isFacingRight = true;
    //플레이어 방향 체크
    public bool isJumping = false;
    //플레이어가 뛰는 중인가?
    public bool isGrounded = false;
    //플레이어가 지면에 있는가?

    public float jumpForce = 650.0f;
    //점프 점프력
    public float maxSpeed = 1.5f;
    //플레이어 이동속도
    public Transform groundCheck;
    //오브젝트가 지면에 있는지 체크
    public LayerMask groundLayers;
    //오브젝트가 지면에 있는지 확인할수있는 레이어
    //private float groundCheckRadius = 0.2f;
    //groundCheck에서 확인 거리

    public Animator animator;
    


    bool isSwording = false;
    bool isArrowing = false;
    bool isHammering = false;
    public GameObject ArrowPrefab;
    public GameObject ArrowPoint;
    Vector3 Arrowspawn;
    public int maxHealth = 3;
    public int Health = 3;
    bool isDead = false;
    bool isInvins = false;
    Rigidbody2D rigid;
    SpriteRenderer render;

    float behavior_ElapsedTime = 0;
    public float behavior_Delay = 0.7f;
    public int damage;
    public GameObject slashpoint;
    public GameObject hammerpoint;
    public bool Is_paused = false;
    public GameObject QuitUI;
    public string prev_level_check;


    public AudioClip Die_sound;
    public AudioSource audioSrc;

    public bool quest1Finished = false;
    public bool quest2Finished = false;
    public bool quest3Finished = false;
    public bool quest4Finished = false;

    public GameObject Quest1item;
    public GameObject Quest2item;
    public GameObject Quest3item;
    public GameObject Quest4item;

    public bool Is_return = false;



    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);


        Screen.SetResolution(1280, 720, false);
        animator = this.GetComponent<Animator>();

        // Image 컴포넌트를 검색해서 참조 변수 값 설정.  
        

    }

    void Start()
    {
        Health = maxHealth;
        //시작할때 최대 체력 설정
        render = GetComponent<SpriteRenderer>();
        QuitUI.SetActive(false);

        audioSrc.clip = Die_sound;

    }

    public void Self_Destroy()
    {
        GameObject.Destroy(gameObject);
    }


    public void Arrowing()
    {
        Arrowspawn = ArrowPoint.transform.position;
        //arrow는 arrowpoint에서 나가도록 설정
        GameObject arrow = Instantiate(ArrowPrefab, Arrowspawn, Quaternion.identity);
        //arrow는 복제(x, y, z설정)
        if (isFacingRight == true)
        {
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(3.0f, 0.0f);
        }
        if (isFacingRight == false)
        {
            arrow.transform.localScale = new Vector3(-1, 1, 1);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.0f, 0.0f);
        }
        //Flip메소드때문에 따로 localscale 반대로함
    }



    public void Die()
    {
        //isDead = true;
        Is_paused = true;
        maxSpeed = 0;

        GameObject.Find("bgm_controller").GetComponent<level1_bgm_controller>().stopbgm();
        audioSrc.loop = false;
        audioSrc.Play();

        GameObject.Find("Fade_out").GetComponent<Fade_out>().Fade_out_enable();
        QuitUI.SetActive(true);
    }



    public void RestoreHp(int restore)
    {
        this.Health = this.Health + restore;
    }


    public void TakeDamage(int damage)
    {
        if (isInvins == false)
        { 
            this.Health = this.Health - damage;
        if (Health == 1)
        {
            isInvins = true;
            StartCoroutine("Invins");
        }
        if (Health == 2)
        {
            isInvins = true;
            StartCoroutine("Invins");
        }
    }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "suicide")
             {
            //Health = 0;
            Die();
        }
        //suicide태그 가진 col과 만날시 바로 사망
    }

     IEnumerator Invins()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime %2 == 0)
                render.color = new Color32(255, 255, 255, 70);
            else
                render.color = new Color32(255, 255, 255, 200);
            //2나눈 나머지값0과 대조하여 알파값 바꿔서 깜빡이는 효과
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        render.color = new Color32(255, 255, 255, 255);
        isInvins = false;
        yield return null;
        //후 초기화
    }






    void Update()
    {
        if (quest1Finished == true)
        {
            Quest1item.gameObject.SetActive(true);
        }
        if (quest2Finished == true)
        {
            Quest2item.gameObject.SetActive(true);
        }
        if (quest3Finished == true)
        {
            Quest3item.gameObject.SetActive(true);
        }
        if (quest4Finished == true)
        {
            Quest4item.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Pause"))
        {
            Is_paused = !Is_paused;
        }

        if (Health == 0)
            {

            if (!isDead)
                Die();
            return;
            //생명력 체크, Health가 0이면 Die 실행
            }

        if (Input.GetButtonDown("Jump") && Is_paused == false)
        {
            if (isGrounded == true)
            {
                Sound_manager.PlaySound("Character_jump");
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            }
        }
        //space눌러서 isgrounded값 참이면 점프(y축 증가)


        behavior_ElapsedTime += Time.deltaTime;
        //조건 충족시 코루틴(애니메이션 제한) 실행
       
        if (Input.GetKeyDown(KeyCode.Z) && behavior_ElapsedTime >= behavior_Delay && Is_paused == false)
        {
            behavior_ElapsedTime = 0;
            StartCoroutine(swording_attack());
        }

        IEnumerator swording_attack()
            {     
            isSwording = true;
            slashpoint.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            isSwording = false;
            slashpoint.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X) && behavior_ElapsedTime >= behavior_Delay && Is_paused == false)
        {
            behavior_ElapsedTime = 0;
            StartCoroutine(arrowing_attack());
        }

        IEnumerator arrowing_attack()
        {
            isArrowing = true;
            Invoke("Arrowing", 0.6f);
            yield return new WaitForSeconds(0.5f);
            isArrowing = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && behavior_ElapsedTime >= behavior_Delay && Is_paused == false)
        {
            behavior_ElapsedTime = 0;
            StartCoroutine(hammering_attack());
        }

        IEnumerator hammering_attack()
        {
            isHammering = true;
            hammerpoint.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            isHammering = false;
            hammerpoint.gameObject.SetActive(false);
        }
        AnimationUpdate();
    }
    //ZXC로 누를때 애니메이션 각각 설정 및 업데이트

    void AnimationUpdate()
    {
        if(isSwording == true) {
            animator.SetBool("isSwording", true);
        }
        else
        {
            animator.SetBool("isSwording", false);
        }

        if (isArrowing == true)
        {
            animator.SetBool("isArrowing", true);
        }
        else
        {
            animator.SetBool("isArrowing", false);
        }

        if (isHammering == true)
        {
            animator.SetBool("isHammering", true);
        }
        else
        {
            animator.SetBool("isHammering", false);
        }
    }

    void FixedUpdate()
    {
         if (Health == 0)
            return;

         //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers); 
         //circle로하니까 벽옆에서도 점프가능해서 바꿈

           isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x, transform.position.y - 0.2f) , 
               new Vector2(transform.position.x, transform.position.y - 0.21f), groundLayers);
         //플레이어가 지면에 닿아있나 체크

            float move = Input.GetAxis ("Horizontal");
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		    //좌우움직임에 따른 애니메이션 설정. move는 -1 ~ 0 ~ 1
            
			this.GetComponent<Rigidbody2D>().velocity =
            new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //좌우움직임 x축 속도 설정

				if ((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true)) 
				{
                     Flip ();
                }
                 // 이동시에 스프라이트가 고정되어 이동하여 이상하니 Flip 을 이용하여 스프라이트 방향 반대로 설정
                 // 왼쪽으로가는데 facingRight가 거짓이면 반대로,, (동시에)그 경우가 반대일경우에도 
    }


    void Flip()
		{
            isFacingRight = !isFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
            //x축 scale 에 -1을 곱하여 반대로 보게하는 메소드 
		}
}