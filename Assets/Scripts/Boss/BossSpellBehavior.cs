using Assets.Scripts;
using UnityEngine;

public class BossSpellBehavior : MonoBehaviour
{
    Animator animator;
    //private GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Appear");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals(Constants.player_name))
        {
            // this code to Damage the player
            //player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
