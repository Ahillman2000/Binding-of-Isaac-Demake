using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public enum opening_direction { Top = 0, Bottom = 1, Left = 2, Right = 3};
    [SerializeField]
    private opening_direction setDirection;

    private RoomDatabase rooms;
    private int rand;
    private bool spawns;

    private float generationTime = 0;
    private float spawnTime = 1;

    private void Start()
    {
        
        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();
        generationTime = rooms.room_count * spawnTime;
        Invoke("Spawn", spawnTime);
        if(rooms.rooms.Count >= rooms.room_count)
        {
            CancelInvoke();
        }
        Destroy(gameObject, generationTime);
    }
    private void Spawn()
    {
        if (spawns == false)
        {


            if (setDirection == opening_direction.Top)
            {
                rand = Random.Range(0, rooms.bottom_facing.Length);
                Instantiate(rooms.bottom_facing[rand], transform.position, rooms.bottom_facing[rand].transform.rotation);

            }
            else if (setDirection == opening_direction.Bottom)
            {

                rand = Random.Range(0, rooms.top_facing.Length);
                Instantiate(rooms.top_facing[rand], transform.position, rooms.top_facing[rand].transform.rotation);

            }
            else if (setDirection == opening_direction.Right)
            {
                rand = Random.Range(0, rooms.left_facing.Length);
                Instantiate(rooms.left_facing[rand], transform.position, rooms.left_facing[rand].transform.rotation);

            }
            else if (setDirection == opening_direction.Left)
            {
                rand = Random.Range(0, rooms.right_facing.Length);
                Instantiate(rooms.right_facing[rand], transform.position, rooms.right_facing[rand].transform.rotation);

            }

            spawns = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<spawnPoint>().spawns == false && spawns == false)
            {
                if(transform.position.x != 0 && transform.position.y != 0)
                {
                    Instantiate(rooms.closed_room, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                
            }
            
            spawns = true;
        }
    }
}
