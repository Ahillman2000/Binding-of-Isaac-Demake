using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameObject gameManagerobj;
    GameManager gameManager;

    GameObject player;
    PlayerItems playerItems;

    [SerializeField] int ScoreIncrease = 1;

    void Start()
    {
        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            playerItems.SetCoins(playerItems.GetCoins() + 1);

            gameManager.SetScore(gameManager.GetScore() + ScoreIncrease);
            Destroy(this.gameObject);
        }
    }
}
