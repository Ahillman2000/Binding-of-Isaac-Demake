using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSpawner : MonoBehaviour
{
    private RoomDatabase rooms;
    private float waitTime = 4.0f;
    void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();
        Instantiate(rooms.door, transform.position, transform.rotation);
        Destroy(gameObject, waitTime);
    }
}
