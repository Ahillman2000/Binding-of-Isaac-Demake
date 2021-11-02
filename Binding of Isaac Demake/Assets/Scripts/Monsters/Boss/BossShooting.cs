using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made a separate boss shooting class for ease of clarity
/// and testing. Will ultimately make use of one shooting
/// script to be used by multiple entities.
/// </summary>
public class BossShooting : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    private float timer;
    private float waitTime;
    //private bool inPatrolArea = false;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

    void Start()
    {
        waitTime = 2.0F;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= (waitTime-0.5F))
        {
            spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        FireProjectile();
    }

    void FireProjectile()
    {
        if (timer >= waitTime)
        {
            Projectile projectile1 = Instantiate(projectile, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Shoot");

            timer = 0;
        }
    }
}
