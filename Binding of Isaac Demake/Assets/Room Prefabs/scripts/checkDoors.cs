using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDoors : MonoBehaviour
{
    private bool detected = false;
    private float waitTime = 4;
    [SerializeField]
    private GameObject wall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "doorSpawner")
        {
            detected = true;
        }
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            if (!detected)
            {
                Instantiate(wall, transform.parent.position, transform.rotation);
                Destroy(gameObject);
                detected = true;
            }
        }

        if(detected)
        {
            Destroy(this.gameObject);
        }
    }
}
