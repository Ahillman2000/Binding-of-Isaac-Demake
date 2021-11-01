using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSpawner : MonoBehaviour
{
    private RoomDatabase rooms;
    private float waitTime = 5.0f;
    void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();

        GameObject door = Instantiate(rooms.door[0], transform.position, transform.rotation);
        door.transform.parent = this.transform.parent;
        Destroy(gameObject, waitTime);
    }
}
