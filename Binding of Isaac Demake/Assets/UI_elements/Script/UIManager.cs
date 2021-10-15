using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI gameObjects
    public Image[] hearts; //health
    public Sprite[] heartSprite;
    public Image powerupIcon;
    public Text coinText, bombText, keyText;

    //vars to be replace
    public int playerHealth, fullHealth, coins, bombs, keys;
    public string powerupInUsed;

    // Start is called before the first frame update
    void Start()
    {

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
}
