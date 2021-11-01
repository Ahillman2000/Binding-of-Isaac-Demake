using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField]
    private AddRoom Room;
    [SerializeField]
    private GameObject RoomObj;

    void Update()
    {
        if (Room.visited == true && Room.enemy_count_per_room == 0)
        {
            FindObjectOfType<AudioManager>().Play("Doors");
            foreach (Transform child in RoomObj.transform)
            {
                if (child.tag == "Door")
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
