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

    void Update()
    {
        if (Room.visited == true && Room.enemy_count_per_room == 0)
        {
            
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
                            FindObjectOfType<AudioManager>().Play("Doors");
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
