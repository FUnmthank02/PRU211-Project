using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    private Transform player;
    public float speed = 2.0f;
    private const float facingToFaceDistance = 9f;
    public BossBehavior bossBehavior;
    private int attackCount = 1;
    public GameObject spell;
    private const float timeBetweenSpell = 0.5f;
    private const float timeDelayForDestroySpell = 0.5f;
    private const int amountOfSpell = 3;
    List<GameObject> spawnedSpells = new List<GameObject>();
    private bool hasStartedCastCoroutine = false;

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
            StartCoroutine(Attack());

            //if (attackCount > 0 && attackCount % 4 == 0 && !hasStartedCastCoroutine)
            //{
            //    hasStartedCastCoroutine = true;
            //    StartCoroutine(Cast());
            //}
            //else
            //{
            //    StartCoroutine(Attack());
            //}
        }
    }

    IEnumerator Attack()
    {
        bossBehavior.handleAttack();
        yield return StartCoroutine(AttackDelayTime());
        attackCount++;
    }

    IEnumerator Cast()
    {
        bossBehavior.handleCast();
        yield return StartCoroutine(WaitAnimationEnd());
        StartCoroutine(SpawnSpell());
        hasStartedCastCoroutine = false;
        yield return StartCoroutine(AttackDelayTime());
        yield return StartCoroutine(SpellDelayTime());
        attackCount = 1;
    }

    IEnumerator WaitAnimationEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator AttackDelayTime()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator SpellDelayTime()
    {
        yield return new WaitForSeconds(3f);
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

    public void HandleSpawn(int orderIndex)
    {
        switch (orderIndex)
        {
            case 0:
                GameObject spellInstance1 = Instantiate(spell, player.position + new Vector3(5, 4, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance1);
                break;
            case 1:
                GameObject spellInstance2 = Instantiate(spell, player.position + new Vector3(0, 4, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance2);
                break;
            case 2:
                GameObject spellInstance3 = Instantiate(spell, player.position + new Vector3(-5, 4, 0), Quaternion.identity);
                spawnedSpells.Add(spellInstance3);
                break;
        }
    }

    IEnumerator DestroyAfterDelay(GameObject spellObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(spellObject);
    }
}