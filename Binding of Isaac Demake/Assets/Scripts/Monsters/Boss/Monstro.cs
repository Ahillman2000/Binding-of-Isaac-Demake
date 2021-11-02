using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : Enemy
{
    private PlayerStats playerStats;

    protected override void Start()
    {
        //base.Start();
        health_ = 5000;
        damage_ = 50;

        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    protected override void Update()
    {
        Movement();
        Attack();

        if (this.health_ <= 0)
        {
            Die();
        }
    }

    protected override void Movement() { }

    protected override void Attack() { }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If Monstro hit by player projectile
        if (collision.tag == "Projectile") 
        {
            health_ -= 100;
            Destroy(collision.gameObject);
        }

        // If Monstro collides with player
        if(collision.tag == "Player")
        {
            playerStats.TakeDamage(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public int GetHealth()
    {
        return health_;
    }
}