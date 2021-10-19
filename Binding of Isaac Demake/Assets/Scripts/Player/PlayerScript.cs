using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int maxLives       = 3;
    private int currentLives                    = 0;

    [SerializeField] private float speed        = 3f;

    [SerializeField] private int attackDamage   = 1;

    [SerializeField] private float shotVelocity = 1.0f;

    void Start()
    {
        currentLives = maxLives;
    }

    public void SetMaxLives(int _maxLives)
    {
        maxLives = _maxLives;
    }
    public int GetMaxLives()
    {
        return maxLives;
    }

    public void SetCurrentLives(int _currentLives)
    {
        currentLives = _currentLives;
    }
    public int GetCurrentLives()
    {
        return currentLives;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }
    public float GetSpeed()
    {
        return speed;
    }

    public void SetAttackDamage(int _attackDamage)
    {
        attackDamage = _attackDamage;
    }
    public int GetAttackDamage()
    {
        return attackDamage;
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
        currentLives -= _damage;

        if(currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("GAME OVER");
    }
}
