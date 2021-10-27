using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI gameObjects
    [SerializeField] private Image[] hearts; //health, preset to 5 now, can add more
    [SerializeField] private Sprite[] heartSprite; //full, half, empty, soul full, soul half
    [SerializeField] private Text scoreText, coinText, bombText, keyText, pickupText;

    //vars to be replace
    private GameObject player;
    private PlayerStats playerStats;
    private PlayerItems playerItems;
    [SerializeField] private int playerHealth, fullHealth, score, coins, bombs, keys;
    [SerializeField] private string powerupInUse;
    private bool pickedUped = false; //check if need to display pickup text

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateCollectables();
        ShowPickupText();
        //update score, add score cal some point later
        scoreText.text = "SCORE: " + score.ToString();
    }

    private void UpdateHealth()
    {
        playerHealth = playerStats.GetCurrentHealth();
        fullHealth = playerStats.GetMaxHealth();
        for (int i = 0; i < hearts.Length; i++)
        {
            if (fullHealth >= playerHealth)
            {
                if (fullHealth / 2.0 > i)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            else
            {
                if (playerHealth / 2.0 > i)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (fullHealth >= playerHealth)
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
            else
            {
                if (fullHealth > i * 2)
                {
                    if (fullHealth - 1 > i * 2)
                    {
                        hearts[i].sprite = heartSprite[0];
                    }
                    else
                    {
                        hearts[i].sprite = heartSprite[1];
                    }
                }else if (playerHealth > i * 2)
                {
                    if (playerHealth - 1 > i * 2)
                    {
                        hearts[i].sprite = heartSprite[3];
                    }
                    else
                    {
                        hearts[i].sprite = heartSprite[4];
                    }
                }
                else
                {
                    hearts[i].sprite = heartSprite[2];
                }
            }
        }
    }

    private void UpdateCollectables()
    {
        coins = playerItems.GetCoins();
        bombs = playerItems.GetBombs();
        keys = playerItems.GetKeys();
        if (coins < 10)
        {
            coinText.text = "x0" + coins.ToString();
        }
        else
        {
            coinText.text = "x" + coins.ToString();
        }
        if (bombs < 10)
        {
            bombText.text = "x0" + bombs.ToString();
        }
        else
        {
            bombText.text = "x" + bombs.ToString();
        }
        if (keys < 10)
        {
            keyText.text = "x0" + keys.ToString();
        }
        else
        {
            keyText.text = "x" + keys.ToString();
        }
    }

    private void ShowPickupText()
    {
        // add ways to put name & description to powerupInUse later
        if (pickedUped)
        {
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        pickedUped = false;
        pickupText.text = powerupInUse;
        yield return new WaitForSeconds(1f);
        pickupText.text = "";
    }
}
