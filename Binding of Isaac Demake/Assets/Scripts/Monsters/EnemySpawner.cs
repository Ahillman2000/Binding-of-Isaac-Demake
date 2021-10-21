using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Enemies
    {
        //public enum State { PATROLING, ATTACKING, FLEEING };
        public GameObject prefab;
        public int count;
        //public int spawn_rate;
        //public int max_health;
        //public int speed;
        //public State current_state;
    }

    [Header("[ENEMY TYPE]")]
    [SerializeField]
    private Enemies[] enemy = null;

    void Start()
    {
        for(int i = 0; i < enemy.Length; i++)
        {
            if(enemy.Length > i)
            {
                for(int j = 0; j < enemy[i].count; j++)
                {
                    Instantiate(enemy[i].prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
            }
        }
    }
}
