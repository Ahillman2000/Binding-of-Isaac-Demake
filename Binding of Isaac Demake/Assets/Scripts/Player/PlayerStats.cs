using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int currentHealth = 6; // Player Curent health (Red Hearts)

    [SerializeField] private int HealthContainers = 6; // Player Heart Containers

    [SerializeField] private int soulHealth = 0;

    [SerializeField] private int playerLives = 0; // PLayer Lives (All times at 0 Unless they have a 1UP item)

    [SerializeField] private float speed            = 3f;

    [SerializeField] private float attackDamage     = 1.0f;

    [SerializeField] private float damageMultiplier = 0f;

    [SerializeField] private float shotVelocity     = 0.8f;

    [SerializeField] private float fireRate         = 0.25f;

    // Lob in here the count for the coins, keys and bombs
    // Luck stat can be added to help for the consumable chance of dropping
    // As well Shot distance [SerializeField] private float shotDistance = ---;

    void Start()
    {
        currentHealth = HealthContainers;
    }

    public void SetMaxHealth(int _maxHealth)
    {
        HealthContainers = _maxHealth;
    }
    public int GetMaxHealth()
    {
        return HealthContainers;
    }

    public void SetCurrentHealth(int _currentHealth)
    {
        currentHealth = _currentHealth;
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void SetSoulHealth(int _soulHealth)
    {
        soulHealth = _soulHealth;
    }
    public int GetsoulHealth()
    {
        return soulHealth;
    }

    public void ResetHealth() //use in player manager
    {
        if (currentHealth > HealthContainers)
        {
            currentHealth = HealthContainers;
        }
    }


    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }
    public float GetSpeed()
    {
        return speed;
    }

    public void SetAttackDamage(float _attackDamage)
    {
        attackDamage = _attackDamage * damageMultiplier;
    }
    public float GetAttackDamage()
    {
        return attackDamage;
    }

    // Eddit Added by Vlad, fix later down the line
    /// <summary>
    public void SetDamageMultiplier(float _damageMultiplier)
    {
        damageMultiplier = _damageMultiplier;
    }
    public float GetDamageMultiplier()
    {
        return damageMultiplier;
    }
    /// </summary>
    /// <param name="_damageMultiplier"></param>

    
    public void SetPlayerLives(int _playerLives)
    {
        playerLives = _playerLives;
    }
    public int GetPlayerLives()
    {
        return playerLives;
    }
   
    public void SetShotVelocity(float _shotVelocity)
    {
        shotVelocity = _shotVelocity;
    }
    public float GetShotVelocity()
    {
        return shotVelocity;
    }

    public void SetFireRate(float _FireRate)
    {
        fireRate = _FireRate;
    }
    public float GetFireRate()
    {
        return fireRate;
    }

    public void TakeDamage(int _damage)
    {
        if (soulHealth > 0)
        {
            soulHealth -= _damage;
        }
        else
        {
            currentHealth -= _damage;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("Lose");
    }
}
