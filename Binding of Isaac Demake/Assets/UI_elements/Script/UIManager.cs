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
    [SerializeField] private GameObject bossUI;
    [SerializeField] private Slider slider;

    //vars to be replace
    private GameObject player, gameManagerobj, boss;
    private PlayerStats playerStats;
    private PlayerItems playerItems;
    private Monstro monstro;
    private GameManager gameManager;
    [SerializeField] private int playerHealth, fullHealth, soulHealth, score, coins, bombs, keys;
    [SerializeField] private float bossFullHealth, bossCurrentHealth;
    [SerializeField] private string powerupInUse;
    private bool pickedUped = false; //check if need to display pickup text
    private GameObject bossRoom;
    private AddRoom addRoom;
    private bool haveBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();
        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();
        bossUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateCollectables();
        UpdateScore();
        UpdateBossUI();
    }

    private void UpdateHealth()
    {
        playerHealth = playerStats.GetCurrentHealth();
        fullHealth = playerStats.GetMaxHealth();
        soulHealth = playerStats.GetsoulHealth();
        for (int i = 0; i < hearts.Length; i++)
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
        for (int i = 0; i < soulhearts.Length; i++)
        {
            if (soulHealth / 2.0 > i)
            {
                soulhearts[i].enabled = true;
            }
            else
            {
                soulhearts[i].enabled = false;
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
        for (int i = 0; i < soulhearts.Length; i++)
        {
            if (soulHealth > i * 2)
            {
                if (soulHealth - 1 > i * 2)
                {
                    soulhearts[i].sprite = heartSprite[3];
                }
                else
                {
                    soulhearts[i].sprite = heartSprite[4];
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
            coinText.text = "0" + coins.ToString();
        }
        else
        {
            coinText.text = "" + coins.ToString();
        }
        if (bombs < 10)
        {
            bombText.text = "0" + bombs.ToString();
        }
        else
        {
            bombText.text = "" + bombs.ToString();
        }
        if (keys < 10)
        {
            keyText.text = "0" + keys.ToString();
        }
        else
        {
            keyText.text = "" + keys.ToString();
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
            scoreText.text = "" + score.ToString();
        }
        else if (score > 9999)
        {
            scoreText.text = "0" + score.ToString();
        }
        else if (score > 999)
        {
            scoreText.text = "00" + score.ToString();
        }
        else if (score > 99)
        {
            scoreText.text = "000" + score.ToString();
        }
        else if (score > 9)
        {
            scoreText.text = "0000" + score.ToString();
        }
        else
        {
            scoreText.text = "00000" + score.ToString();
        }

    }

    private void UpdateBossUI()
    {
        if (bossRoom == null)
        {
            foreach (GameObject room in GameObject.FindGameObjectsWithTag("Rooms"))
            {
                if (room.GetComponent<AddRoom>().roomInstance == AddRoom.roomType.BOSS)
                {
                    bossRoom = room; //put in update instead of start because generation takes time
                    addRoom = bossRoom.GetComponent<AddRoom>();
                }
            }
        }
        if (GameObject.FindGameObjectWithTag("Boss") != null)
        {
            if (!haveBoss)
            {
                boss = GameObject.FindGameObjectWithTag("Boss");
                monstro = boss.GetComponent<Monstro>();
                bossFullHealth = monstro.GetHealth();
                slider.maxValue = bossFullHealth;
                haveBoss = true; // so it won't constantly set boss
            }
        }
        else
        {
            haveBoss = false;
        }
        if (addRoom != null)
        {
            if (addRoom.visited && haveBoss)
            {
                bossUI.SetActive(true);
            }
            else
            {
                bossUI.SetActive(false);
            }
        }
        if (haveBoss)
        {
            bossCurrentHealth = monstro.GetHealth();
            slider.value = bossCurrentHealth;
        }
    }
}
