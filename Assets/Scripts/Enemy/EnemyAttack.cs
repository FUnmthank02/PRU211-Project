using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;  // Số lượng HP bị giảm khi tấn công

    private bool isDamaging = false;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);  // Gọi phương thức TakeDamage để giảm HP của người chơi
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDamaging)
            {
                isDamaging = true;
                StartCoroutine(DoDamageOverTime(other.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private IEnumerator DoDamageOverTime(GameObject player)
    {
        while (isDamaging)
        {
            // Gọi phương thức TakeDamage của PlayerHealth để giảm HP của người chơi
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);

            yield return new WaitForSeconds(0);
        }
    }

}
