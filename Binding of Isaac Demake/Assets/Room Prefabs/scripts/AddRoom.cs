using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    public enum roomType {EMPTY, ITEM, ENEMY, BOSS, NumberOfTypes};
    public roomType roomInstance;
    private int random;
    private RoomDatabase rooms;
    public GameObject itemSpawner;

    private void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();
        itemSpawner.GetComponent<ItemSpawner>().enabled = false;
        gameObject.GetComponent<EnemySpawner>().enabled = false;
        random = Random.Range(0, (int)roomType.NumberOfTypes);
        roomInstance = (roomType)random;
        if(roomInstance == roomType.BOSS || roomInstance == roomType.ITEM)
        {
            roomInstance = roomType.EMPTY;
        }

        rooms.RoomList[0].GetComponent<AddRoom>().roomInstance = roomType.EMPTY;
        rooms.RoomList.Add(this.gameObject);
    }
}
