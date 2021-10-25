using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject gameManagerobj;
    GameManager gameManager;

    GameObject player;
    PlayerStats playerStats;
    PlayerItems playerItems;

    //UI gameObjects
    public Image[] hearts; //health
    public Sprite[] heartSprite;
    public Image powerupIcon;
    public Text coinText, bombText, keyText;
    public Text score;

    //vars to be replace
    public int playerHealth, fullHealth;
    public string powerupInUsed;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        //update health bar
        for (int i = 0; i < hearts.Length; i++)
        {
            if (fullHealth / 2 > i)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (playerHealth > i * 2)
            {
                if (playerHealth - 1 > i * 2)
                {
                    hearts[i].sprite = heartSprite[0];
                }
                else
                {
                    hearts[i].sprite = heartSprite[1];
                }
            }
            else
            {
                hearts[i].sprite = heartSprite[2];
            }
        }

        //collectable texts
        if (playerItems.GetCoins() < 10)
        {
            coinText.text = "x0" + playerItems.GetCoins().ToString();
        }
        else
        {
            coinText.text = "x" + playerItems.GetCoins().ToString();
        }
        if (playerItems.GetBombs() < 10)
        {
            bombText.text = "x0" + playerItems.GetBombs().ToString();
        }
        else
        {
            bombText.text = "x" + playerItems.GetBombs().ToString();
        }
        if (playerItems.GetKeys() < 10)
        {
            keyText.text = "x0" + playerItems.GetKeys().ToString();
        }
        else
        {
            keyText.text = "x" + playerItems.GetKeys().ToString();
        }

       // score.text = gameManager.GetScore().ToString();
    }
}
