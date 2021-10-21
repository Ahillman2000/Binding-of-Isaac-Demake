using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Transform enemy;
    private List<Vector3> movePoint = new List<Vector3>();
    private float speed = 1.0F;
    private float timer = 0.0F;
    private float waitPeriod = 0.0F;
    private int current_point = 0;
    private bool inPatrolArea = false;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            /// Adds movePoints to list
            movePoint.Add(new Vector3());

            /// Generate random move positions
            float movePosX = Random.Range(transform.position.x - 2, transform.position.x + 2);
            float movePosY = Random.Range(transform.position.y - 2, transform.position.y + 2);
            movePoint[i] = new Vector2(movePosX, movePosY);
        }

        player = GameObject.FindWithTag("Player");
        enemy = transform; /// for readability
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (inPatrolArea)
        {
            /// Chase player
            enemy.position = Vector2.MoveTowards(enemy.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (!inPatrolArea)
        {
            /// Enemies move to each point after waiting period is over
            if (timer >= waitPeriod)
            {
                enemy.position = Vector2.MoveTowards(enemy.position, movePoint[current_point], speed * Time.deltaTime);
            }

            /// Cycle through random move points
            if (enemy.position == movePoint[current_point])
            {
                timer = 0;
                waitPeriod = Random.Range(1, 3);
                int rand_point = Random.Range(0, movePoint.Count - 1);

                /// Generate new random position if it is the same as the current
                if (rand_point == current_point)
                {
                    rand_point = Random.Range(0, movePoint.Count - 1);
                }

                /// Set the next movement point for the enemy to go to
                current_point = rand_point;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            inPatrolArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inPatrolArea = false;
    }
}
