using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaper : Enemy
{
    public GameObject coinDrop;
    public GameObject heartDrop;
    public GameObject bombDrop;

    private PlayerStats playerStats;

    protected override void Start()
    {
        //base.Start();
        health_ = 150;
        damage_ = 100;

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
        if (Random.value > 0.5)
        {
            Instantiate(coinDrop, transform.position, Quaternion.identity);
        }   //50% = 0.5, 80% = 0.2, 30% = 0.7

        if (Random.value > 0.6)
        {
            Instantiate(heartDrop, transform.position + transform.up, Quaternion.identity);
        }   //50% = 0.5, 80% = 0.2, 30% = 0.7

        if (Random.value > 0.7)
        {
            Instantiate(bombDrop, transform.position - transform.up, Quaternion.identity);
        }   //50% = 0.5, 80% = 0.2, 30% = 0.7

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            health_ -= 50;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Player")
        {
            if (playerStats.GetCurrentHealth() > 0)
            {
                playerStats.TakeDamage(1); // handle in player script?
            }
        }
    }
}
