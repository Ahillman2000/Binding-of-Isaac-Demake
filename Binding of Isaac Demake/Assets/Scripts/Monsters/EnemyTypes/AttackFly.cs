using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFly : Enemy
{
    private GameObject player;
    private PlayerStats playerStats;
    private UIManager uIManager;

    private Color RED = new Color(0.78F, 0, 0, 0.8F);

    public GameObject coinDrop;
    public GameObject heartDrop;
    public GameObject bombDrop;

    protected override void Start()
    {
        //base.Start();
        health_ = 100;
        damage_ = 25;

        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        uIManager = GameObject.Find("UI").GetComponent<UIManager>();
    }

    protected override void Update()
    {
        //base.Update();
        Movement();
        Attack();

        if (this.health_ <= 0)
        {
            Die(); 
        }
    }

    protected override void Movement() {}

    protected override void Attack() {}

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
        if (collision.tag == "Player")
        {
            if(playerStats.GetCurrentHealth() > 0)
            {
                playerStats.TakeDamage(1); // handle in player script?
            }
        }

        if (collision.tag == "Projectile")
        {
            health_ -= 50; /// enemy damage

            GetComponentInChildren<Renderer>().material.color = RED; /// enemy damage colour

            Destroy(collision.gameObject); /// destroy projectile
        }
    }
}


