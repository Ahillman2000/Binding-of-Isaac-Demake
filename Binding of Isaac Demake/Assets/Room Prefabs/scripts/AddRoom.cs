using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomDatabase rooms;

    private void Start()
    {

        rooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomDatabase>();
        rooms.rooms.Add(this.gameObject);       
    }
}
