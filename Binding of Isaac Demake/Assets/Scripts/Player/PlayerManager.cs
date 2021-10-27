using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;

    PlayerItems playerItems;

    GameObject gameManagerobj;
    GameManager gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerItems = player.GetComponent<PlayerItems>();

        gameManagerobj = GameObject.Find("GameManager");
        gameManager = gameManagerobj.GetComponent<GameManager>();
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
                return true;
            case Constants.TAG_HALO:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.3f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.3f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetMaxHealth(playerStats.GetMaxHealth() + 1);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;
            case
                Constants.TAG_GM:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 1.0f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;
            case
                Constants.TAG_RR:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.1f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;
            case
                Constants.TAG_VIRUS:
                playerStats.SetSpeed(playerStats.GetSpeed() - 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.5f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() - 0.3f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;
            case
                Constants.TAG_PH:
                playerStats.SetDamageMultiplier(playerStats.GetDamageMultiplier() + 2f);
                playerStats.SetAttackDamage((playerStats.GetAttackDamage() + 4.0f) * playerStats.GetDamageMultiplier());
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;

            case
                Constants.TAG_1UP:
                playerStats.SetPlayerLives(playerStats.GetPlayerLives() + 1);
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;

            case
                Constants.TAG_MEP:
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + playerItems.GetCoinDamageAC());
                FindObjectOfType<AudioManager>().Play("PowerUp");
                return true;
            case
                Constants.TAG_PT:
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 3.5f);
                FindObjectOfType<AudioManager>().Play("PowerUp");
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
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_HHP:
                playerStats.SetCurrentHealth(playerStats.GetCurrentHealth() + 1);
                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_FSHP:

                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;
            case
                Constants.TAG_HSHP:

                gameManager.SetScore(gameManager.GetScore() + GenerateRandomNumber());
                return true;

            default:
                Debug.LogWarning($"Warning: No handler Implemented for tag{obj}.tag. ");
                return false;

        }
    }
}
