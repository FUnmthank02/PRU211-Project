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
    private SpriteRenderer SpriteRende;
    private bool trigger;
    private bool active;
    private bool load;

    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        SpriteRende = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!trigger)
            {
                StartCoroutine(ActiveSpikeTrap());
            }

            player = collision.GetComponent<PlayerHealth>();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }

    private void Update()
    {
        if (active && player != null)
        {
            player.TakeDamage(damage);
        }

    }

    private IEnumerator ActiveSpikeTrap()
    {

        trigger = true;
        SpriteRende.color = Color.red;

        yield return new WaitForSeconds(activateDelay);
        SpriteRende.color = Color.white;
        active = true;
        anim.SetBool("Active", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        trigger = false;
        anim.SetBool("Active", false);
    }

}
