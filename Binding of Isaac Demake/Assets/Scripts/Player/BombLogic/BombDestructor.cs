using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestructor : MonoBehaviour
{
    [SerializeField] bool playerIn = false;
    [SerializeField] bool bossIn   = false;
    

    [SerializeField] public GameObject gameObj;

    [SerializeField] public float explosionTimerCD = 3.0f;
    [SerializeField] public float explosionTimer   = 3.0f;

    [SerializeField] public bool isExploded = false;

    GameObject player;
    GameObject boss;
    PlayerStats playerStats;
    Monstro monstro;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        playerStats = player.GetComponent<PlayerStats>();
        monstro = boss.GetComponent<Monstro>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
            Debug.Log("player in");
            
        }
        if (other.tag == "Boss")
        {
            bossIn = true;
            Debug.Log("boss in");
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
            Debug.Log("player out");
        }
        if (other.tag == "Boss")
        {
            bossIn = false;
            Debug.Log("boss out");
        }
    }
    void Update()
    {
        if (isExploded == true)
        {
            Timer();
        }
    }
    void Timer()
    {
        if (explosionTimer > 0)
        {
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0 && isExploded)
            {
                if (playerIn)
                {
                    playerStats.TakeDamage(2);
                    FindObjectOfType<AudioManager>().Play("Explosion");
                    Destroy(gameObj);
                    explosionTimer = explosionTimerCD;
                    isExploded = false;
                }
                if (bossIn)
                {
                    monstro.SetHealth(monstro.GetHealth() - 50);
                    FindObjectOfType<AudioManager>().Play("Explosion");
                    Destroy(gameObj);
                    explosionTimer = explosionTimerCD;
                    isExploded = false;
                }

                else
                {
                    FindObjectOfType<AudioManager>().Play("Explosion");
                    Destroy(gameObj);
                    explosionTimer = explosionTimerCD;
                    isExploded = false;
                }
            }
        }
    }

    
}
