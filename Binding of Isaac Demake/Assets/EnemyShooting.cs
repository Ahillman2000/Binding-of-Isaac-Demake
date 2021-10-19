using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private GameObject player;
    private float fireRate;
    private float nextFire;
    private bool inPatrolArea = false;

    void Start()
    {
        fireRate = 3.0F;
        nextFire = Time.time;

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (inPatrolArea)
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            inPatrolArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            inPatrolArea = false;
        }
    }
}
