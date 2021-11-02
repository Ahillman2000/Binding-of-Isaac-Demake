using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Traverse : MonoBehaviour
{
    [SerializeField]
    private enum DIRECTION {UP, DOWN, LEFT, RIGHT};
    [SerializeField]
    DIRECTION directon;

    private GameObject Player;
    private GameObject Camera;
    private GridGraph gridGraph;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Camera = GameObject.FindWithTag("MainCamera");
        gridGraph = AstarPath.active.data.gridGraph;
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

            gridGraph.center = new Vector2(Camera.transform.position.x, Camera.transform.position.y);
            AstarPath.active.Scan(); /// Scans the level to configure the pathfinding navigation grid
        }
    }
}
