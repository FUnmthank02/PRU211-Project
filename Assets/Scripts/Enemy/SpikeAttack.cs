using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageInterval = 2f;    // Thời gian giữa các lần gây sát thương

    private bool isDamaging = false;
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

            yield return new WaitForSeconds(damageInterval);
        }
    }
}
