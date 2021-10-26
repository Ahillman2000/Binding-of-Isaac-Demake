using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private int currentHealth                       = 0;

    [SerializeField] private int maxHealth          = 3;

    [SerializeField] private int playerLives        = 0;
    
    [SerializeField] private float speed            = 3f;

    [SerializeField] private float attackDamage     = 1.0f;

    [SerializeField] private float damageMultiplier = 1.0f;

    [SerializeField] private float shotVelocity     = 0.8f;

    // Lob in here the count for the coins, keys and bombs
    // Luck stat can be added to help for the consumable chance of dropping
    // As well Shot distance [SerializeField] private float shotDistance = ---;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(int _maxHealth)
    {
        maxHealth = _maxHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetCurrentHealth(int _currentHealth)
    {
        currentHealth = _currentHealth;
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
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

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

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
