using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("doorSpawner"))
        {
            Destroy(gameObject);
        }
    }
}
