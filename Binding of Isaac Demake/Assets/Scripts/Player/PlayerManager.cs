using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;

    PlayerItems playerItems;

    GameObject gameManagerobj, uIobj;
    GameManager gameManager;
    UIManager uIManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();

        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();

        uIobj = GameObject.Find("UI");
        uIManager = uIobj.GetComponent<UIManager>();
    }

    private int GenerateRandomNumber()
    {
        int _number = Random.Range(1, 15);
        return _number;
    }

    //public bool PickUpItem(GameObject obj)
    public bool PickUpItem(GameObject obj)
    {
        switch (obj.tag)
        {
            //Items
            case Constants.TAG_MM:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.3f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.3f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.4f);
                playerStats.SetMaxHealth(playerStats.GetMaxHealth() + 1);
                playerStats.SetDamageMultiplier(playerStats.GetDamageMultiplier() + 1.5f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("Magic Mush- ALL STATS UP");
                return true;
            case Constants.TAG_HALO:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.3f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.3f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetMaxHealth(playerStats.GetMaxHealth() + 1);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("The Halo - ALL STATS UP");
                return true;
            case
                Constants.TAG_GM:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 1.0f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("Growth Hormone - Health + DMG UP");
                return true;
            case
                Constants.TAG_RR:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.1f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("Roid Rage - Shot speed + range up");
                return true;
            case
                Constants.TAG_VIRUS:
                playerStats.SetSpeed(playerStats.GetSpeed() - 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.5f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() - 0.3f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("Speed Ball - Move speed + shot speed up");
                return true;
            case
                Constants.TAG_PH:
                playerStats.SetDamageMultiplier(playerStats.GetDamageMultiplier() + 2f);
                playerStats.SetAttackDamage((playerStats.GetAttackDamage() + 4.0f) * playerStats.GetDamageMultiplier());
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("Polyphemus - DMG UP");
                return true;

            case
                Constants.TAG_1UP:
                playerStats.SetPlayerLives(playerStats.GetPlayerLives() + 1);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("1up - extra life");
                return true;

            case
                Constants.TAG_MEP:
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + playerItems.GetCoinDamageAC());
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("MONEY = POWER");
                return true;
            case
                Constants.TAG_PT:
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 3.5f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                uIManager.ShowPickupText("PROPTOSIS - DMG UP");
                return true;

            //Consumables
            case
                Constants.TAG_COIN:
                playerItems.SetCoins(playerItems.GetCoins() + 1);
                playerItems.SetCoinDamageAC(playerItems.GetCoins() * playerItems.GetCoinDamage());
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_BOMB:
                playerItems.SetBombs(playerItems.GetBombs() + 1);
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_KEY:
                playerItems.SetKeys(playerItems.GetKeys() + 1);
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_FHP:
                playerStats.SetCurrentHealth(playerStats.GetCurrentHealth() + 2);
                playerStats.ResetHealth();
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_HHP:
                playerStats.SetCurrentHealth(playerStats.GetCurrentHealth() + 1);
                playerStats.ResetHealth();
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_FSHP:
                playerStats.SetSoulHealth(playerStats.GetsoulHealth() + 2);
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_HSHP:
                playerStats.SetSoulHealth(playerStats.GetsoulHealth() + 1);
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;

            default:
                Debug.LogWarning($"Warning: No handler Implemented for tag{obj}.tag. ");
                return false;

        }
    }
}
