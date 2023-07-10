using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public healthBar healthBar;
	public Animator Animator => this.GetComponent<Animator>();
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{

	}


	public void TakeDamage(int damage)
	{
		Animator.SetTrigger("Hurt");
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		// Play death animation or sound, remove object from scene, etc.
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("bullet"))
		{
			TakeDamage(10);
		}
	}
}
