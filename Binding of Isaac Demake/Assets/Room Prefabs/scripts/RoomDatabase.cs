using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDatabase : MonoBehaviour
{
    public GameObject[] top_facing;
    public GameObject[] bottom_facing;
    public GameObject[] right_facing;
    public GameObject[] left_facing;

    public GameObject[] entry_room;
    public GameObject closed_room;

    public GameObject door;

    public int room_count;

    public List<GameObject> rooms;
    
    private int rand;
    private float waitTime = 3.0f;
    private bool spawnBoss;

    private void Start()
    {
        SpawnFirst();
    }

    void SpawnFirst()
    {
        rand = Random.Range(0, entry_room.Length);
        Instantiate(entry_room[rand], transform.position, entry_room[rand].transform.rotation);
    }

    private void Update()
    {
        if (waitTime <= 0 && spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    rooms[i].GetComponent<AddRoom>().roomInstance = AddRoom.roomType.BOSS;
                    spawnBoss = true;
                }
            }

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    
}
