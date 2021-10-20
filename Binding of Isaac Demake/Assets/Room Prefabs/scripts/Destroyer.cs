using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rooms"))
        {
            Destroy(collision.gameObject);
        }

    }

    private float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
    }
}
