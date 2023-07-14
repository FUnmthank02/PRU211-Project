using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapSpike : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("SpikeTrap Timer")]
    [SerializeField] private float activateDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool trigger;
    private bool active;
    private bool load;
<<<<<<< Updated upstream
=======
    private bool playerInRange; // Biến kiểm tra người chơi có trong phạm vi của bẫy gai hay không
>>>>>>> Stashed changes

    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
            player = collision.GetComponent<PlayerHealth>();

            if (!trigger)
            {
                StartCoroutine(ActiveSpikeTrap());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constants.player_name)
        {
            playerInRange = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }

    private void Update()
    {
        if (active && playerInRange && player != null)
        {
            player.TakeDamage(damage);
<<<<<<< Updated upstream
=======
            Debug.Log("xxx");
>>>>>>> Stashed changes
        }
    }

    private IEnumerator ActiveSpikeTrap()
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
            StartCoroutine(ActiveSpikeTrap());
        }
    }

}
