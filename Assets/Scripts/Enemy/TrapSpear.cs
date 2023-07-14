using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpear : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Spear Trap Timer")]
    [SerializeField] private float activateDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool trigger;
    private bool active;
    private bool load;
    private bool playerInRange;

    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!trigger)
            {
                StartCoroutine(ActiveSpearTrap());
            }

            player = collision.GetComponent<PlayerHealth>();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constants.player_name)
        {
            player = null;
        }
    }

    private void Update()
    {
        if (active && player != null)
        {
            player.TakeDamage(damage);
        }

    }

    private IEnumerator ActiveSpearTrap()
    {

        trigger = true;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(activateDelay);

        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("Active", true);

        yield return new WaitForSeconds(activeTime);

        active = false;
        trigger = false;
        anim.SetBool("Active", false);

        if (playerInRange)
        {
            StartCoroutine(ActiveSpearTrap());
        }
    }

}
