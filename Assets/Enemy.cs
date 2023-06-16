using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int heath = 100;
    public GameObject deathEffect;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        heath -= damage;
        if (heath <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
