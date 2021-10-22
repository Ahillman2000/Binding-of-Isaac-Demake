using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearProjectile : MonoBehaviour
{
    public Rigidbody2D RB;

    private GameObject player;
    private PlayerStats playerStats;
    private playerControllerScript playerControllerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerControllerScript = player.GetComponent<playerControllerScript>();

        //Debug.Log(playerControllerScript.playerDirection);

        switch (playerControllerScript.playerDirection)
        {
            case playerControllerScript.PlayerDirection.DOWN:
                RB.velocity = transform.up * playerStats.GetShotVelocity() * -1;
                break;
            case playerControllerScript.PlayerDirection.UP:
                RB.velocity = transform.up * playerStats.GetShotVelocity(); 
                break;
            case playerControllerScript.PlayerDirection.LEFT:
                RB.velocity = transform.right * playerStats.GetShotVelocity() * -1;
                break;
            case playerControllerScript.PlayerDirection.RIGHT:
                RB.velocity = transform.right * playerStats.GetShotVelocity();
                break;
            default:
                RB.velocity = transform.up * playerStats.GetShotVelocity() * -1;
                break;
        }
    }

    void Update()
    {
        Destroy(this.gameObject, 3f);
    }
}
