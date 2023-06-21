using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    public GameObject goblin;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void handleRun()
    {
        animator.SetBool(Constants.animation_goblin_move, true);
    }

    public void handleStopRun()
    {
        animator.SetBool(Constants.animation_goblin_move, false);
    }

    public void handleDealth()
    {
        animator.SetTrigger(Constants.animation_goblin_death);
    }

    public void handleAttack()
    {
        animator.SetTrigger(Constants.animation_goblin_attack);
    }
    
    public void handleTakeHit()
    {
        animator.SetTrigger(Constants.animation_goblin_take_hit);
    }

}
