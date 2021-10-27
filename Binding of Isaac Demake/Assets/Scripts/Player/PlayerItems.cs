using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private int keys  = 0;
    [SerializeField] private int bombs = 0;

    [SerializeField] private float coinDamage = 0.04f; // This is used for the Money = Power item ( 1 coin would give the player 0.04 damage)
    [SerializeField] private float coinDamageAC = 0f;    // overall damage is acumulated here, once M=P it will be used for the calculation

    void Start()
    {
        
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int _coins)
    {
        coins = _coins;
    }

    //Vlad Edit
    public float GetCoinDamage()
    {
        return coinDamage;
    }

    // multiply the number of coins by  0.04 ( coin Damage)

    public float GetCoinDamageAC()
    {
        return coinDamageAC;
    }
    public void SetCoinDamageAC(float _coinDamageAC)
    {
        coinDamageAC = _coinDamageAC;
    }

    public int GetKeys()
    {
        return keys;
    }

    public void SetKeys(int _keys)
    {
        keys = _keys;
    }

    public int GetBombs()
    {
        return bombs;
    }

    public void SetBombs(int _bombs)
    {
        bombs = _bombs;
    }

    void Update()
    {
        //coinDamageAC = coins * coinDamage;
        // SetCoinDamageAC(coinDamageAC);
    }
}
