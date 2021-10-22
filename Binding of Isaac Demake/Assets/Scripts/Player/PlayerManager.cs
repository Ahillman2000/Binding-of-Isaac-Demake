using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    //public bool PickUpItem(GameObject obj)
    public bool PickUpItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case Constants.TAG_MM:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.3f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.3f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.4f);
                playerStats.SetMaxHealth(playerStats.GetMaxHealth() + 1);
                playerStats.SetDamageMultiplier(playerStats.GetDamageMultiplier() + 1.5f);
                return true;
            case Constants.TAG_HALO:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.3f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.3f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetMaxHealth(playerStats.GetMaxHealth() + 1);
                return true;
            case
                Constants.TAG_GM:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 1.0f);
                return true;
            case
                Constants.TAG_RR:
                playerStats.SetSpeed(playerStats.GetSpeed() + 0.4f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() + 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.1f);
                return true;
            case
                Constants.TAG_VIRUS:
                playerStats.SetSpeed(playerStats.GetSpeed() - 0.2f);
                playerStats.SetAttackDamage(playerStats.GetAttackDamage() + 0.5f);
                playerStats.SetShotVelocity(playerStats.GetShotVelocity() - 0.3f);
                return true;
            case
                Constants.TAG_PH:
                playerStats.SetAttackDamage((playerStats.GetAttackDamage() + 4.0f) * 2);
                return true;
            case

                Constants.TAG_1UP:
                playerStats.SetPlayerLives(playerStats.GetPlayerLives() + 1);
                return true;

            default:
                Debug.LogWarning($"Warning: No handler Implemented for tag{obj}.tag. ");
                return false;

        }

    }
}
