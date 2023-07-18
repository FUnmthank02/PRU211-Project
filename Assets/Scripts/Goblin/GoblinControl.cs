using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GoblinControl : MonoBehaviour
{
    public GameController controller;
    private Transform player;
    public float speed = 2.0f;
    private const float facingToFaceDistance = 2f;
    public GoblinBehavior goblinBehavior;
    public GoblinHealth goblinHealth;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 5;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Get distance between enermies and player
        Vector3 direction = player.position - transform.position;

        // check direction ahead to flip enermies faces
        bool isFlipped = direction.x > 0;
        var distanceToPlayer = direction.magnitude;
        this.GetComponent<SpriteRenderer>().flipX = !isFlipped;

        if (isFlipped)
        {
            attackPoint.position = transform.position + new Vector3(1, 0, 0);
        }
        else
        {
            attackPoint.position = transform.position + new Vector3(-1, 0, 0);
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // control enermies behavior
        if (distanceToPlayer > facingToFaceDistance)
        {
            goblinBehavior.handleRun();
        }
        else
        {
            goblinBehavior.handleStopRun();
            Attack();
        }

        if (goblinHealth.healthSlider.value <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void Attack()
    {
        goblinBehavior.handleAttack();
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayers)
        {
            // this code to Damage the player
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}