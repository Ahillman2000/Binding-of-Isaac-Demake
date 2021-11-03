using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField]
    private AddRoom Room;
    [SerializeField]
    private GameObject RoomObj;
    [SerializeField]
    private KeyUnlock bossDoor;
    private bool sounded = false;

    void Update()
    {
        if (Room.visited == true && Room.enemy_count_per_room == 0)
        {
            if (Room.roomInstance != AddRoom.roomType.EMPTY && !sounded)
            {
                FindObjectOfType<AudioManager>().Play("Doors");
                sounded = true;
            }
            foreach (Transform child in RoomObj.transform)
            {
                if (child.tag == "Door")
                {
                    Destroy(child.gameObject);
                }
                if (child.name == "RoomSpawnPoints")
                {
                    Transform p = child;
                    foreach (Transform d in p)
                    {
                        if (d.tag == "Door")
                        {
                            Destroy(d.gameObject);
                        }
                    }
                }
                
            }

            if(bossDoor.keyed == true)
            {
                Destroy(bossDoor.gameObject);
            }
        }
    }
}
