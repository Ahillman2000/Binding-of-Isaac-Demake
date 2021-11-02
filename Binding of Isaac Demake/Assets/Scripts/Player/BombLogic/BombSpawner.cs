using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    GameObject player;
    public GameObject bombToSpawn;
    private BombDestructor bombDestructor;

    PlayerItems playerItems;

    void Start()
    {
        bombDestructor = bombToSpawn.GetComponent<BombDestructor>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerItems = player.GetComponent<PlayerItems>();

    }
    void Update()
    {
        if (playerItems.GetBombs() == 0)
        {

        }

        if (playerItems.GetBombs() > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpawnBomb();
            }
        }
       
    }


    void SpawnBomb()
    {
        Instantiate(bombToSpawn, transform.position, Quaternion.identity);
        bombDestructor.isExploded = true;
        playerItems.SetBombs(playerItems.GetBombs() - 1);
    }
    
    void BombExplode()
    {

    }
}
