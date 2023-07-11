using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
    public GameObject Bullet;
    public Rigidbody2D rb;
	public GameObject impactEffect;

    // Use this for initialization
    void Start () {
		
		rb.velocity = transform.right * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("boss"))
        {
            Destroy(Bullet);
        }
    }

}
