using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearProjectile : MonoBehaviour
{
    public Rigidbody2D RB;

    private GameObject player;
    private PlayerScript playerScript;
    private playerControllerScript playerControllerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        playerControllerScript = player.GetComponent<playerControllerScript>();

        //Debug.Log(playerControllerScript.playerDirection);

        switch (playerControllerScript.playerDirection)
        {
            case playerControllerScript.PlayerDirection.DOWN:
                RB.velocity = transform.up * playerScript.GetShotVelocity() * -1;
                break;
            case playerControllerScript.PlayerDirection.UP:
                RB.velocity = transform.up * playerScript.GetShotVelocity(); 
                break;
            case playerControllerScript.PlayerDirection.LEFT:
                RB.velocity = transform.right * playerScript.GetShotVelocity() * -1;
                break;
            case playerControllerScript.PlayerDirection.RIGHT:
                RB.velocity = transform.right * playerScript.GetShotVelocity();
                break;
            default:
                RB.velocity = transform.up * playerScript.GetShotVelocity() * -1;
                break;
        }
    }

    void Update()
    {
        Destroy(this.gameObject, 3f);
    }
}
