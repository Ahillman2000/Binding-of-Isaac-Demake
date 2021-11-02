using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private PlayerStats playerStats;
	private Rigidbody2D rb;
	private GameObject player;
	private Vector2 moveDirection;
	private float moveSpeed = 7.5f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");
		playerStats = player.GetComponent<PlayerStats>();

		moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

		Destroy(gameObject, 3f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (playerStats.GetCurrentHealth() > 0)
			{
				playerStats.TakeDamage(2);
			}
			Destroy(gameObject);
		}

		/// ew
		if (collision.gameObject.name == "Wall" || collision.gameObject.name == "wall" || collision.gameObject.name == "DoorClosed1(Clone)")
		{
			Destroy(gameObject);
		}
	}
}
