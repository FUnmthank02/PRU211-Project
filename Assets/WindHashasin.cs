using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class WindHashasin : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 0f;
    public float moveHoz;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject gameover;

    public HashasinHealth healthBar;

    public float airAttackDuration = 0.5f;
    private bool isJumping = false;
    private bool isAirAttacking = false;
    private bool isAttacking = false;
    public Transform AtkPoint;
    public float atkRange = 0.5f;
    public LayerMask enemyLayer;
    public AssasinSkill skill;
    public Hashagi hashagi;
    public bool facingRight = true;

    public Atk atk;


    public Transform firePoint;
    public GameObject bulletPrefab;

    public float rollSpeed = 10.0f;
    public float rollDuration = 0.25f;
    private bool isRolling = false;

    private int jumpCount = 0;
    private SpriteRenderer spriteRenderer;

    private bool isRunning = false;

    [SerializeField] private int maxJumpCount = 0;
    private Rigidbody2D rb => this.GetComponent<Rigidbody2D>();
    public Animator Animator => this.GetComponent<Animator>();
    [SerializeField] AudioSource audiSource;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //move
        moveHoz = Input.GetAxis("Horizontal");
        Animator.SetFloat("Speed", System.Math.Abs(moveHoz));
        if (moveHoz != 0)
        {
            transform.position += new Vector3(moveHoz * speed * Time.deltaTime, 0, 0);
            Animator.SetFloat("Speed", 1);
            Invoke("PlayMoveSound", 2f);
        }
        if (moveHoz > 0 && facingRight)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                transform.Translate(Vector3.left * 1);
            }
            Flip();
            Invoke("PlayMoveSound", 2f);

        }
        if (moveHoz < 0 && !facingRight)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                transform.Translate(Vector3.right * 1);
            }
            Flip();
            Invoke("PlayMoveSound", 2f);

        }

        //Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.Animator.SetTrigger("Jump");
            this.doJump();
        }
        if (Input.GetKeyDown(KeyCode.W) && speed > 1)
        {
            this.Animator.CrossFade("Jump", 0.001f);
            this.doJump();
        }


        //roll
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            StartCoroutine(Roll());
        }

        //atk while idle
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(ATK());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(Cast());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Cast2());
        }

        //def
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.Animator.SetTrigger("Def");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (this.jumpCount == 0)
            {
                StartCoroutine(Tele());
            }
        }
    }
    void PlayMoveSound()
    {
        AudioManager.Instance.PlaySFX("move");
    }
    IEnumerator Tele()
    {
        Animator.SetTrigger("tele");
        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0.5f);
        if (facingRight)
        {
            transform.Translate(Vector3.left * 3);
        }
        if (!facingRight)
        {
            transform.Translate(Vector3.right * -3);
        }
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }

    //cast spell
    IEnumerator Cast()
    {
        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0f);
        skill.gameObject.SetActive(true);
        skill.transform.position += new Vector3(0.001f, 0, 0);
        this.Animator.SetTrigger("Skill");
        StartCoroutine(Cancel());
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }

    IEnumerator Cancel()
    {

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0.8f);
        skill.gameObject.SetActive(false);
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }


    //cast hasagi
    IEnumerator Cast2()
    {

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0f);
        hashagi.gameObject.SetActive(true);
        hashagi.transform.position += new Vector3(0.001f, 0, 0);
        this.Animator.SetTrigger("Atk3");
        StartCoroutine(Cancel2());
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }

    IEnumerator Cancel2()
    {

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0.8f);
        hashagi.gameObject.SetActive(false);
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }


    //atk melee
    IEnumerator ATK()
    {

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0f);
        atk.gameObject.SetActive(true);
        atk.transform.position += new Vector3(0.001f, 0, 0);
        this.Animator.SetTrigger("Atk");
        StartCoroutine(CancelATK());
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }

    IEnumerator CancelATK()
    {

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0.5f);
        atk.gameObject.SetActive(false);
        // Lệnh khác sẽ được chạy sau khi animation chạy xong
    }

    //roll
    IEnumerator Roll()
    {
        isRolling = true;
        rb.velocity = transform.forward * rollSpeed;
        Animator.CrossFade("Roll", 0.1f);
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        Animator.CrossFade("Idle", 0.1f);
    }

    void doJump()
    {
        if (jumpCount >= maxJumpCount)
        {
            return;
        }
        this.rb.AddForce(new Vector2(0, this.jumpforce));
        jumpCount++;
    }

    void doLand()
    {
        this.jumpCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            doLand();
            isJumping = false;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    IEnumerator AirAttack()
    {
        isAirAttacking = true;
        Animator.CrossFade("AirAttack", 0.1f);
        yield return new WaitForSeconds(airAttackDuration);
        isAirAttacking = false;
        Animator.CrossFade("Jump", 0.1f);
    }
    void Flip()
    {
        transform.Rotate(0f, 180, 0f);
        facingRight = !facingRight;
    }

    public void TakeDamage(int damage)
    {
        Animator.SetTrigger("Hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Animator.SetTrigger("Death");
        Destroy(gameObject);
        gameover.SetActive(true);
    }
}
