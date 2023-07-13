using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
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
            enemy.SetHeath(5);
        }
    }
}
