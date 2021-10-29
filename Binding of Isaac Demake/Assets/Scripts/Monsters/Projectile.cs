using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Rigidbody2D rb;
	private GameObject target;
	private Vector2 moveDirection;
	private float moveSpeed = 10f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.Equals(target))
		{
			Debug.Log("Hit!");
		}

		if(!col.gameObject.CompareTag("Enemy"))
        {
			Debug.Log(col.gameObject.name);
			Destroy(gameObject);
		}
	}
}
