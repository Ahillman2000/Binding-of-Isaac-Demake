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
        //if enemy count == 0, destroy all doors in this room
        if (Room.visited == true )
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
