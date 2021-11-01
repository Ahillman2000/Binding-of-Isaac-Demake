using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traverse : MonoBehaviour
{
    [SerializeField]
    private enum DIRECTION {UP, DOWN, LEFT, RIGHT};
    [SerializeField]
    DIRECTION directon;

    private GameObject Player;
    private GameObject Camera;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Camera = GameObject.FindWithTag("MainCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (directon == DIRECTION.UP)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 25, 0);
                Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + 30, 0);
            }
            
            if (directon == DIRECTION.DOWN)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 25, 0);
                Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 30, 0);
            }
            
            if (directon == DIRECTION.RIGHT)
            {
                Player.transform.position = new Vector3(Player.transform.position.x + 21, Player.transform.position.y, 0);
                Camera.transform.position = new Vector3(Camera.transform.position.x + 30, Camera.transform.position.y, 0);
            }
            
            if (directon == DIRECTION.LEFT)
            {
                Player.transform.position = new Vector3(Player.transform.position.x - 21, Player.transform.position.y, 0);
                Camera.transform.position = new Vector3(Camera.transform.position.x - 30, Camera.transform.position.y, 0);
            }
        }
    }
}
