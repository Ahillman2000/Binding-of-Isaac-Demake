using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooter : Enemy
{
    public GameObject coinDrop;
    public GameObject heartDrop;
    public GameObject bombDrop;

    protected override void Start()
    {
        //base.Start();
        health_ = 100;
        damage_ = 50;
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

        if (Random.value > 0.6)
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
    }
}
