using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private bool isInvulnerable = false;
    public GameObject gameover;

    void Start()
    {
        currentHealth = startingHealth;  // Khởi tạo HP ban đầu
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float damageAmount)
    {
        if (isInvulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, startingHealth);

        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            Die();  // Xử lý khi HP của người chơi giảm xuống 0 hoặc âm
        }
    }

    private void Die()
    {
        gameover.SetActive(true);
        Destroy(gameObject);
       
    }

    private IEnumerator Invunerability()
    {
        isInvulnerable = true;  // Bắt đầu trạng thái bất tử
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
        isInvulnerable = false;  // Kết thúc trạng thái bất tử
    }
}
