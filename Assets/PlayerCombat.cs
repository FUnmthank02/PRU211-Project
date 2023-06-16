using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        if (Input.GetButtonDown("Fire3"))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetBool("IsAttacking", true);
    }


}
