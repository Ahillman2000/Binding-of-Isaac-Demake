using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug code for player stats
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerStats.TakeDamage(1);
            Debug.Log(playerStats.GetCurrentHealth());
        }
    }
}
