using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertDoor : MonoBehaviour
{
    public GameObject boss_door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if(collision.tag == "doorSpawner")
        {    
            Instantiate(boss_door, collided.transform.position, collided.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
