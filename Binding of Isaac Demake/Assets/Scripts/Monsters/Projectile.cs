using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private PlayerStats playerStats;
	private Rigidbody2D rb;
	private GameObject player;
	private Vector2 moveDirection;
	private float moveSpeed = 5f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");
		playerStats = player.GetComponent<PlayerStats>();
		moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}

    private void OnCollisionEnter2D(Collision2D col)
    {

		if (col.gameObject.Equals(player))
		{
			if (playerStats.GetCurrentHealth() > 0)
			{
				playerStats.TakeDamage(1);
			}
		}

		if(!col.gameObject.CompareTag("Enemy"))
        {
			//Debug.Log(col.gameObject.name);
			Destroy(gameObject);
		}
	}
}
