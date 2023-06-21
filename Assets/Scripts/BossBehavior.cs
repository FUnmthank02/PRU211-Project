using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject boss;
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
    
    public void handleWalk()
    {
        animator.SetBool(Constants.animation_boss_walk, true);
    }

    public void handleStopWalking()
    {
        animator.SetBool(Constants.animation_boss_walk, false);
    }

    public void handleDealth()
    {
        animator.SetTrigger(Constants.animation_boss_death);
    }

    public void handleHurt()
    {
        animator.SetTrigger(Constants.animation_boss_hurt);
    }

    public void handleAttack()
    {
        animator.SetTrigger(Constants.animation_boss_attack);
    }

    public void handleCast()
    {
        animator.SetTrigger(Constants.animation_boss_cast);
    }

}
