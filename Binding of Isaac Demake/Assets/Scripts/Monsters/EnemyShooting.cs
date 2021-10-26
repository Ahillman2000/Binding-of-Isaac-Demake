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
    //private bool inPatrolArea = false;

    void Start()
    {
        fireRate = 1.5F;
        nextFire = Time.time;

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        FireProjectile();
    }

    void FireProjectile()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
