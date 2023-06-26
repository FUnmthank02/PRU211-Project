using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {

        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);

        }
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage item
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
        }
    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
