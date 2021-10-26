using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnapper : MonoBehaviour
{
    private Camera mainCamera;
    private RoomDatabase roomDatabase;

    private void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        roomDatabase = GameObject.FindWithTag("RoomManager").GetComponent<RoomDatabase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mainCamera.transform.position = this.transform.parent.position;
        }
    }
}
