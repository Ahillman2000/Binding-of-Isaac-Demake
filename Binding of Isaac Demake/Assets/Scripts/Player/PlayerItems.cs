using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private int keys  = 0;
    [SerializeField] private int bombs = 0;

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
        
    }
}
