using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Destroy(collision.gameObject); // destroy projectile

            if(transform.parent.parent != null)
            {
                Destroy(transform.parent.parent.gameObject); // destroy enemy container
            }
            else
            {
                Destroy(transform.parent.gameObject); 
            }
        }
    }
}
