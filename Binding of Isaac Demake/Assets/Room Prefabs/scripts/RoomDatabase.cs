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

    private void Start()
    {
        SpawnFirst();
    }

    void SpawnFirst()
    {
        rand = Random.Range(0, entry_room.Length);
        Instantiate(entry_room[rand], transform.position, entry_room[rand].transform.rotation);
    }
}
