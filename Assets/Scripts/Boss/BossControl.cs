using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public GameObject spell;
    public BossBehavior bossBehavior;
    private Transform player;
    private float speed = 2.0f;
    private const float facingToFaceDistance = 5f;
    private int attackCount = 1;
    private const float timeBetweenSpell = 0.5f;
    private const float timeDelayForDestroySpell = 1.2f;
    private const int amountOfSpell = 3;
    List<GameObject> spawnedSpells = new List<GameObject>();
    private bool hasStartedCastCoroutine = false;
    private bool hasStartedAttackCoroutine = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find(Constants.player_name).transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Get distance between enermies and player
        Vector3 direction = player.position - transform.position;

        // check direction ahead to flip enermies faces
        bool isFlipped = direction.x > 0;
        this.GetComponent<SpriteRenderer>().flipX = isFlipped;
        var distanceToPlayer = direction.magnitude;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        
        // control enermies behavior
        if (distanceToPlayer > facingToFaceDistance)
        {
             bossBehavior.handleWalk();
        }
        else
        {
            bossBehavior.handleStopWalking();

            if (attackCount == 4 && !hasStartedCastCoroutine)
            {
                hasStartedCastCoroutine = true;
                StartCoroutine(Cast());
            }
            else if (attackCount != 4 && !hasStartedAttackCoroutine)
            {
                hasStartedAttackCoroutine = true;
                StartCoroutine(Attack());
            }
        }
    }

    // attack
    IEnumerator Attack()
    {
        bossBehavior.handleAttack();
        yield return StartCoroutine(AttackDelayTime());
        attackCount++;
        hasStartedAttackCoroutine = false;
    }

    // cast spells
    IEnumerator Cast()
    {
        bossBehavior.handleCast();
        yield return StartCoroutine(WaitAnimationEnd());
        StartCoroutine(SpawnSpell());
        yield return StartCoroutine(AttackDelayTime());
        attackCount = 1;
        hasStartedCastCoroutine = false;
    }

    // wait util animation end
    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }

    // wait for the next attack
    IEnumerator AttackDelayTime()
    {
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator SpawnSpell()
    {
        player = GameObject.Find(Constants.player_name).transform;

        //Spawn enemies in a random position
        for (int i = 0; i < amountOfSpell; i++)
        {
            HandleSpawn(i);
            yield return new WaitForSeconds(timeBetweenSpell);
        }
        // Destroy the spawned spell instances
        foreach (GameObject spawnedSpell in spawnedSpells)
        {
            StartCoroutine(DestroyAfterDelay(spawnedSpell, timeDelayForDestroySpell));
        }

    }

    // handle spawn spells
    public void HandleSpawn(int orderIndex)
    {
        switch (orderIndex)
        {
            case 0:
                GameObject spellInstance1 = Instantiate(spell, player.position + new Vector3(0, 6, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance1);
                break;
            case 1:
                GameObject spellInstance2 = Instantiate(spell, player.position + new Vector3(3, 6, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance2);
                break;
            case 2:
                GameObject spellInstance3 = Instantiate(spell, player.position + new Vector3(-3, 6, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance3);
                break;
        }
    }

    // destroy spells after delay time
    IEnumerator DestroyAfterDelay(GameObject spellObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(spellObject);
    }
}