using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaper : Enemy
{
    protected override void Start()
    {
        //base.Start();
        health_ = 150;
        damage_ = 100;
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
        if (collision.tag == "Projectile")
        {
            health_ -= 50;
            Destroy(collision.gameObject);
        }
    }
}
