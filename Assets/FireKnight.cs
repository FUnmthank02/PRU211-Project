using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class FireKnight : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce = 0f;

    public float airAttackDuration = 0.5f;
    private bool isJumping = false;
    private bool isAirAttacking = false;
    private bool isAttacking = false;
    public Transform AtkPoint;
    public float atkRange = 0.5f;
    public LayerMask enemyLayer;
    public float moveHoz;
    public float moveVer;
    public bool facingRight = true;

    public KnightScript atk;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float rollSpeed = 10.0f;
    public float rollDuration = 0.25f;
    private bool isRolling = false;

    public float health = 0f;
    private int jumpCount = 0;
    private SpriteRenderer spriteRenderer;

    private bool isRunning = false;

    [SerializeField] private int maxJumpCount = 0;
    private Rigidbody2D rb => this.GetComponent<Rigidbody2D>();
    public Animator Animator => this.GetComponent<Animator>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHoz = Input.GetAxis("Horizontal");
        Animator.SetFloat("Speed", Math.Abs(moveHoz));
        if (moveHoz != 0)
        {
            transform.position += new Vector3(moveHoz * speed * Time.deltaTime, 0, 0);
            Animator.SetFloat("Speed", 1);
        }
        if (moveHoz > 0 && !facingRight)
        {
            Flip();
        }
        if (moveHoz < 0 && facingRight)
        {
            Flip();
        }

        //atk && move
        if (speed == 1 && Input.GetKeyDown(KeyCode.J))
        {
            Animator.SetFloat("Speed", 0);
            this.Animator.CrossFade("Atk", 0001f);
        }
        if (speed == 1 && Input.GetKeyDown(KeyCode.K))
        {
            Animator.SetFloat("Speed", 0);
            this.Animator.CrossFade("Atk2", 0001f);
        }
        if (speed == 1 && Input.GetKeyDown(KeyCode.I))
        {
            Animator.SetFloat("Speed", 0);
            this.Animator.CrossFade("Atk3", 0001f);
        }

        //atk while idle
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(ATK());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.Animator.SetTrigger("Atk2");
        }
/*        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(Cast2());
        }*/
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(Cast());
        }

        //roll
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            StartCoroutine(Roll());
        }

        //jump
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

        //def
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.Animator.SetTrigger("Def");
        }
    }

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

    IEnumerator Cast()
    {
        // Chạy animation
        Animator.SetTrigger("Atk3");

        // Đợi cho đến khi animation chạy xong
        yield return new WaitForSeconds(0.6f);

        // Lệnh khác sẽ được chạy sau khi animation chạy xong
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator Roll()
    {
        isRolling = true;
        rb.velocity = transform.forward * rollSpeed;
        Animator.CrossFade("Roll", 0.1f);
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        Animator.CrossFade("Idle", 0.1f);
    }

    IEnumerator AirAttack()
    {
        isAirAttacking = true;
        Animator.CrossFade("AirAttack", 0.1f);
        yield return new WaitForSeconds(airAttackDuration);
        isAirAttacking = false;
        Animator.CrossFade("Jump", 0.1f);
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
    }

    void Flip()
    {
        transform.Rotate(0f, 180, 0f);
        facingRight = !facingRight;
    }
}
