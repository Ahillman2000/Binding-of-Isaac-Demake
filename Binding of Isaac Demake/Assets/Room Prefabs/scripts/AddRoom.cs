using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    public enum roomType {EMPTY, ITEM, ENEMY, BOSS, NumberOfTypes};
    public roomType roomInstance;
    public GameObject itemSpawner;
    public bool visited = false;
    public int enemy_count_per_room;

    public GameObject enemyParent;
    private int random;
    private RoomDatabase rooms;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();

        itemSpawner.GetComponent<ItemSpawner>().enabled = false;
        this.gameObject.GetComponent<EnemySpawner>().enabled = false;
        
        random = Random.Range(0, (int)roomType.NumberOfTypes);
        roomInstance = (roomType)random;
        if(roomInstance == roomType.BOSS || roomInstance == roomType.ITEM)
        {
            roomInstance = roomType.EMPTY;
        }
        
        rooms.RoomList.Add(this.gameObject);
        rooms.RoomList[0].GetComponent<AddRoom>().roomInstance = roomType.EMPTY;

        foreach (Transform child in transform)
        {
            if (child.tag == "Enemy")
            {
                child.transform.parent = enemyParent.transform;
                enemy_count_per_room = enemyParent.transform.childCount;
            }
        }

    }

    private void Update()
    {
        foreach (Transform child in enemyParent.transform)
        {
            if (child.tag == "Enemy")
            {
                enemy_count_per_room = enemyParent.transform.childCount;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            visited = true;
        }
    }
}
