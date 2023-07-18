using Assets.Scripts;
using UnityEngine;

public class BossSpellBehavior : MonoBehaviour
{
    public WindHashasin hashasin;
    Animator animator;
    //private GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Appear");
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals(Constants.player_name))
        {
            hashasin.TakeDamage(20);
        }
    }*/
}


