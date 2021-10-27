using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI gameObjects
    [SerializeField] private Image[] hearts; //health, preset to 5 now, can add more
    [SerializeField] private Sprite[] heartSprite;
    [SerializeField] private Image powerupIcon;
    [SerializeField] private Text scoreText, coinText, bombText, keyText;

    //vars to be replace
    private GameObject player;
    [SerializeField] private int playerHealth, fullHealth, score, coins, bombs, keys;
    [SerializeField] private string powerupInUsed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //update health bar
        playerHealth = player.GetComponent<PlayerScript>().GetCurrentLives();
        fullHealth = player.GetComponent<PlayerScript>().GetMaxLives();
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

        //collectable texts
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

        //update score, add score cal some point later
        scoreText.text = "SCORE: " + score.ToString();
    }
}
