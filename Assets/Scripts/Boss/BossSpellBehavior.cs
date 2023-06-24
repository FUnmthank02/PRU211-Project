using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellBehavior : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Appear");
    }
}
