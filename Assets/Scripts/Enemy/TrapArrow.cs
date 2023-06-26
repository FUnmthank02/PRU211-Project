using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArrow : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireArrow;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;
        fireArrow[FindFireArrow()].transform.position = firePoint.position;
        fireArrow[FindFireArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireArrow()
    {
        for (int i = 0; i < fireArrow.Length; i++)
        {
            if (!fireArrow[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
