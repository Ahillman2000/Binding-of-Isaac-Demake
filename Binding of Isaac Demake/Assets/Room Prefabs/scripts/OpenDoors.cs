using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    private EnemySpawner enemies;
    private AddRoom Room;

    private GameObject player;
    private GameObject RoomObj;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        Room = GameObject.FindGameObjectWithTag("Rooms").GetComponent<AddRoom>();
        RoomObj = GameObject.FindGameObjectWithTag("Rooms");
        enemies = GameObject.FindGameObjectWithTag("Rooms").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        //if enemy count == 0, destroy all doors in this room
        if (this.Room.visited == true)
        {
            FindObjectOfType<AudioManager>().Play("Doors");
            foreach (Transform child in this.RoomObj.transform)
            {
                if (child.tag == "Door")
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
