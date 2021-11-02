using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDoors : MonoBehaviour
{
    private bool detected = false;
    private float waitTime = 1.0f;
    [SerializeField]
    private GameObject wall;
    private RoomDatabase rooms;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "doorSpawner")
        {
            detected = true;
        }
        
    }

    private void Update()
    {
        
        if(detected)
        {
            Destroy(this.gameObject);
        }

        
        if (waitTime <= 0)
        {
            if (!detected)
            {
                Instantiate(wall, transform.parent.position, transform.rotation);
                detected = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
    }
}
