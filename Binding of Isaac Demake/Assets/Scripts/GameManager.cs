using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool debug;

    private GameObject player;
    private PlayerStats playerStats;
    private PlayerItems playerItems;

    private float floatScore = 0;
    private int intScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void Score()
    {
        floatScore += Time.deltaTime;
        intScore = (int)floatScore;
    }

    public int GetScore()
    {
        return intScore;
    }

    public void SetScore(int _score)
    {
        floatScore = (float)_score;
    }

    void Debugger()
    {
        // Debug code for player stats
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStats.TakeDamage(1);
            Debug.Log(playerStats.GetCurrentHealth());
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            playerItems.SetCoins(playerItems.GetCoins() + 1);
            playerItems.SetKeys(playerItems.GetKeys() + 1);
            playerItems.SetBombs(playerItems.GetBombs() + 1);
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            playerItems.SetCoins(playerItems.GetCoins() - 1);
            playerItems.SetKeys(playerItems.GetKeys() - 1);
            playerItems.SetBombs(playerItems.GetBombs() - 1);
        }

        //Debug.Log(intScore);
    }

    void Update()
    {
        if (debug)
        {
            Debugger();
        }
        Score();
    }
}
