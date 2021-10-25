using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject player;
    PlayerItems playerItems;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerItems.SetBombs(playerItems.GetBombs() + 1);
            Destroy(this.gameObject);
        }
    }
}
