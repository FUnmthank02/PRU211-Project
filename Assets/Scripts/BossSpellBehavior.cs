using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellBehavior : MonoBehaviour
{
    Animator animator;
    private const float timeWaitForDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Appear");
    }

    // Update is called once per frame
    void Update()
    {
        //DestroySpell();
    }

    void DestroySpell()
    {
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(timeWaitForDestroy);
        Destroy(gameObject);
    }
}
