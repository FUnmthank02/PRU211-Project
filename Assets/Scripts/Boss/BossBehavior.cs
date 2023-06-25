using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject boss;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // handle walk
    public void handleWalk()
    {
        animator.SetBool(Constants.animation_boss_walk, true);
    }

    // handle stop walking
    public void handleStopWalking()
    {
        animator.SetBool(Constants.animation_boss_walk, false);
    }

    // handle death
    public void handleDealth()
    {
        animator.SetTrigger(Constants.animation_boss_death);
    }

    // handle hurt
    public void handleHurt()
    {
        animator.SetTrigger(Constants.animation_boss_hurt);
    }

    // handle attack
    public void handleAttack()
    {
        animator.SetTrigger(Constants.animation_boss_attack);
    }

    // handle cast spell
    public void handleCast()
    {
        animator.SetTrigger(Constants.animation_boss_cast);
    }

}
