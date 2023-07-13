using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssasinSkill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoblinHealth enemy = collision.GetComponentInChildren<GoblinHealth>();
        if (enemy != null)
        {
            enemy.SetHeath(20);
        }
    }
}
