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

    public GameObject door;

    public int room_count = 10;

    public List<GameObject> RoomList;
    
    private int rand;
    private float waitTime = 5.0f;
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
            rand = Random.Range(1, RoomList.Count);

            RoomList[rand].GetComponent<AddRoom>().roomInstance = AddRoom.roomType.ITEM;
            RoomList[rand].GetComponent<AddRoom>().itemSpawner.GetComponent<ItemSpawner>().enabled = true;
            for (int i = 0; i < RoomList.Count; i++)
            {
                if(i != rand)
                {
                    Destroy(RoomList[i].GetComponent<AddRoom>().itemSpawner);
                }

                if(RoomList[i].GetComponent<AddRoom>().roomInstance == AddRoom.roomType.ENEMY)
                {
                    RoomList[i].GetComponent<EnemySpawner>().enabled = true;
                }

                if (i == RoomList.Count - 1)
                {
                    RoomList[i].GetComponent<AddRoom>().roomInstance = AddRoom.roomType.BOSS;
                    spawnBoss = true;
                }   
            }
        }
        else if (waitTime > 0 && spawnBoss == false)
        {
            waitTime -= Time.deltaTime;
        }
    }
    
}
