using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestructor : MonoBehaviour
{
    [SerializeField] public GameObject gameObj;

    [SerializeField] public float explosionTimerCD = 3.0f;
    [SerializeField] public float explosionTimer   = 3.0f;

    [SerializeField] public bool isExploded = false;

    Collider2D[] inExplosionRadius = null;
    [SerializeField] public float ExplosionForceMulti = 2.0f;
    [SerializeField] public float ExplosionRadius = 2.0f;

    GameObject player;
    PlayerStats playerStats;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Explode()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if(o_rigidbody != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if(distanceVector.magnitude > 0 )
                {
                    /*float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                    Invoke("NegateForce", 2f);
                    CancelInvoke();*/
                    playerStats.TakeDamage(2);

                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
    void Update()
    {
        if (isExploded == true)
        {
            Timer();
        }
    }
    void Timer()
    {
        if (explosionTimer > 0)
        {
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0 && isExploded)
            {
                FindObjectOfType<AudioManager>().Play("Explosion");
                Destroy(gameObj);
                Explode();
                explosionTimer = explosionTimerCD;
                isExploded = false;
                
            }
        }
    }

    
}
