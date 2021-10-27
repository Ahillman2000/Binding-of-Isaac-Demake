using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI gameObjects
    [SerializeField] private Image[] hearts; //health, preset to 6 now, can add more
    [SerializeField] private Image[] soulhearts;
    [SerializeField] private Sprite[] heartSprite; //full, half, empty, soul full, soul half
    [SerializeField] private Text scoreText, coinText, bombText, keyText, pickupText;

    //vars to be replace
    private GameObject player;
    private PlayerStats playerStats;
    private PlayerItems playerItems;
    private GameObject gameManagerobj;
    private GameManager gameManager;
    [SerializeField] private int playerHealth, fullHealth, score, coins, bombs, keys;
    [SerializeField] private string powerupInUse;
    private bool pickedUped = false; //check if need to display pickup text

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();
        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateCollectables();
        //ShowPickupText();
        UpdateScore();
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

    public void ShowPickupText(string item)
    {
        pickedUped = true;
        if (pickedUped)
        {
            powerupInUse = item;
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        pickedUped = false;
        pickupText.text = powerupInUse;
        yield return new WaitForSeconds(2f);
        pickupText.text = "";
    }

    private void UpdateScore()
    {
        score = gameManager.GetScore();
        if (score > 99999)
        {
            scoreText.text = "SCORE: " + score.ToString();
        }
        else if (score > 9999)
        {
            scoreText.text = "SCORE: 0" + score.ToString();
        }
        else if (score > 999)
        {
            scoreText.text = "SCORE: 00" + score.ToString();
        }
        else if (score > 99)
        {
            scoreText.text = "SCORE: 000" + score.ToString();
        }
        else if (score > 9)
        {
            scoreText.text = "SCORE: 0000" + score.ToString();
        }
        else
        {
            scoreText.text = "SCORE: 00000" + score.ToString();
        }

    }
}
