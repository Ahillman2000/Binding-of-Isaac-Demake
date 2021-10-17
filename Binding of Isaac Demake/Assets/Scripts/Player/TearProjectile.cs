using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D RB;

    GameObject player;
    playerControllerScript playerControllerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<playerControllerScript>();

        //Debug.Log(playerControllerScript.playerDirection);

        switch (playerControllerScript.playerDirection)
        {
            case playerControllerScript.PlayerDirection.DOWN:
                RB.velocity = transform.up * speed * -1;
                break;
            case playerControllerScript.PlayerDirection.UP:
                RB.velocity = transform.up * speed; 
                break;
            case playerControllerScript.PlayerDirection.LEFT:
                RB.velocity = transform.right * speed * -1;
                break;
            case playerControllerScript.PlayerDirection.RIGHT:
                RB.velocity = transform.right * speed;
                break;
            default:
                RB.velocity = transform.up * speed * -1;
                break;
        }

    }

    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

}
