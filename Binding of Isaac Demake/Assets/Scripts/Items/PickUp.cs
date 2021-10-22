using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    /*
    GameObject player;
    PlayerScript playerScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.CompareTag("Player"))
        {
            // refereamce playerScript.SetMaxLives 
           //playerScript.SetSpeed(playerScript.GetSpeed() + 1.0f);
            Destroy(gameObject);
        }*/

        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if(manager)
        {
            bool pickedUp = manager.PickUpItem(gameObject);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
