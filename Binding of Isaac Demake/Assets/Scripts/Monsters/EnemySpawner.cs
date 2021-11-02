using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Enemies
    {
        public GameObject prefab;
        public int count;
    }

    [Header("[Custom Initialisation]")]
    [SerializeField]
    private Enemies[] enemy = null;

    [Header("[Random Initialisation]")]
    [SerializeField]
    private GameObject[] random_enemy = null;

    private GameObject player;
    private Transform enemyP; //fix for room-enemy detection, by Stephanie
    private List<GameObject> enemy_container = new List<GameObject>();
    private int room_capacity = 0;
   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Vector2 spawner_pos = transform.position;
        room_capacity = Random.Range(1, 4);

        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "GameObject")
            {
                enemyP = child;
            }
        }

        /// Custom Enemy Instantiation
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy.Length > i)
            {
                for (int j = 0; j < enemy[i].count; j++) //what is this second for loop for?
                {
                    /// Generate random position
                    Vector2 random_pos;
                    random_pos.x = Random.Range(spawner_pos.x - 2, spawner_pos.x + 2);
                    random_pos.y = Random.Range(spawner_pos.y - 2, spawner_pos.y + 2);

                    /// Instantiate enemy and to container list
                    GameObject enemy_inst = Instantiate(enemy[i].prefab, new Vector2(random_pos.x, random_pos.y), Quaternion.identity);
                    enemy_inst.transform.parent = enemyP;
                    enemy_inst.GetComponent<EnemyAi>().target = player.transform;
                    enemy_container.Add(enemy_inst);
                }
            }
        }

        /// Random Enemy Instantiation 
        if (random_enemy.Length > 0 && room_capacity > 0)
        {
            for (int i = 0; i < room_capacity; i++)
            {
                /// Generate random position
                Vector2 random_pos;
                random_pos.x = Random.Range(spawner_pos.x - 2, spawner_pos.x + 2);
                random_pos.y = Random.Range(spawner_pos.y - 2, spawner_pos.y + 2);

                /// Generate random enemy type
                int random_index = Random.Range(0, random_enemy.Length);

                /// Instantiate enemy and to container list
                GameObject enemy_inst = Instantiate(random_enemy[random_index], new Vector2(random_pos.x, random_pos.y), Quaternion.identity);
                enemy_inst.transform.parent = enemyP;

                if (enemy_inst.GetComponent<EnemyAi>() != null)
                {
                    enemy_inst.GetComponent<EnemyAi>().target = player.transform;
                }
                if (enemy_inst.GetComponent<AIDestinationSetter>() != null)
                {
                    enemy_inst.GetComponent<AIDestinationSetter>().target = player.transform;
                }
                enemy_container.Add(enemy_inst);
            }
        }
    }
}
