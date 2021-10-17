using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug code for player stats
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerScript.TakeDamage(1);
            Debug.Log(playerScript.GetCurrentLives());
        }
    }
}
