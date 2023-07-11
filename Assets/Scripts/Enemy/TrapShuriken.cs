using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShuriken : MonoBehaviour
{
    public int damageAmount = 10;

    private bool isDamaging = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Constants.player_name))
        {

            StartCoroutine(DoDamageOverTime(collision.gameObject));

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Constants.player_name))
        {
            isDamaging = false;
        }
    }


    private IEnumerator DoDamageOverTime(GameObject player)
    {

        // Gọi phương thức TakeDamage của PlayerHealth để giảm HP của người chơi
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(damageAmount);

        yield return new WaitForSeconds(0);

    }
}
