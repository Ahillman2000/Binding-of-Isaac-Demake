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
    // Enemy[] enemy 

    /// If one spawner per room then this could be used to get enemy room count
    private List<GameObject> enemy_container = new List<GameObject>();

    void Awake()
    {
        Vector2 spawner_pos = transform.position;
        Vector2 spawner_size = GetComponent<BoxCollider2D>().size;

        for(int i = 0; i < enemy.Length; i++)
        {
            if(enemy.Length > i)
            {
                for(int j = 0; j < enemy[i].count; j++)
                {
                    /// Generate random position
                    Vector2 random_pos;
                    random_pos.x = Random.Range(spawner_pos.x-spawner_size.x/2, spawner_pos.x+spawner_size.x/2);
                    random_pos.y = Random.Range(spawner_pos.y-spawner_size.y/2, spawner_pos.y+spawner_size.y/2);

                    /// Instantiate enemy and to container list
                    GameObject enemy_inst = Instantiate(enemy[i].prefab, new Vector2(random_pos.x, random_pos.y), Quaternion.identity);
                    enemy_container.Add(enemy_inst);
                }
            }
        }
    }
}
