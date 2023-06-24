using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    public GameObject goblin;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // handle run
    public void handleRun()
    {
        animator.SetBool(Constants.animation_goblin_move, true);
    }

    // handle stop run
    public void handleStopRun()
    {
        animator.SetBool(Constants.animation_goblin_move, false);
    }

    // handle death
    public void handleDealth()
    {
        animator.SetTrigger(Constants.animation_goblin_death);
    }

    // handle attack
    public void handleAttack()
    {
        animator.SetTrigger(Constants.animation_goblin_attack);
    }
    
    // handle take hit
    public void handleTakeHit()
    {
        animator.SetTrigger(Constants.animation_goblin_take_hit);
    }

}
