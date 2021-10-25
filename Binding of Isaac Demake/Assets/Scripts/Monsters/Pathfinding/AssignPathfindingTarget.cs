using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AssignPathfindingTarget : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        /// Locates all Gameobjects in the scene tagged with Enemy and sets
        /// the destination target of the pathfinding script for all of them
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(enemy.GetComponent<AIDestinationSetter>() != null)
            {
                enemy.GetComponent<AIDestinationSetter>().target = player.transform;
            }
            if (enemy.GetComponent<EnemyAi>() != null)
            {
                enemy.GetComponent<EnemyAi>().target = player.transform;
            }
        }
    }
}
