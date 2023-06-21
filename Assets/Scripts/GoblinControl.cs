using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinControl : MonoBehaviour
{
    private Transform player;
    public float speed = 2.0f;
    private const float facingToFaceDistance = 2f;
    public GoblinBehavior goblinBehavior;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag(Constants.player_name).transform;
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
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // control enermies behavior
        if (distanceToPlayer > facingToFaceDistance)
        {
            goblinBehavior.handleRun();
        }
        else
        {
            goblinBehavior.handleStopRun();
            goblinBehavior.handleAttack();
        }
    }
}