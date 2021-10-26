using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    public enum roomType {EMPTY, ITEM, ENEMY, BOSS, NumberOfTypes};
    [SerializeField]
    public roomType roomInstance;
    private int random;
    private RoomDatabase rooms;

    private void Start()
    {
        random = Random.Range(0, (int)roomType.NumberOfTypes);
        roomInstance = (roomType)random;
        if(roomInstance == roomType.BOSS)
        {
            roomInstance = roomType.EMPTY;
        }

        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();
        rooms.rooms.Add(this.gameObject);       
    }
}
