using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Enemies
    {
        public enum State { PATROLING, ATTACKING, FLEEING };
        public GameObject prefab;
        public int count;
        public int spawn_rate;
        public int max_health;
        public int speed;
        public State current_state;
    }

    [Header("[ENEMY TYPE]")]
    [SerializeField]
    private Enemies[] enemy = null;

    // refactor this filth
    void Start()
    {
        if (enemy.Length > 0)
        {
            // Enemy Type 1
            for (int i = 0; i < enemy[0].count; i++)
            {
                Instantiate(enemy[0].prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }

        if (enemy.Length > 1)
        {
            // Enemy Type 2
            for (int i = 0; i < enemy[1].count; i++)
            {
                Instantiate(enemy[1].prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }
}
