using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D player_box_collder;

    private List<Vector3> movePoint = new List<Vector3>();
    private float speed = 1.0F;
    private int current_point = 0;
    private bool inPatrolArea = false;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            movePoint.Add(new Vector3());

            // Generate random move positions
            float movePosX = Random.Range(transform.position.x - 2, transform.position.x + 2);
            float movePosY = Random.Range(transform.position.y - 2, transform.position.y + 2);
            movePoint[i] = new Vector2(movePosX, movePosY);
        }

        player = GameObject.FindWithTag("Player");
        player_box_collder = player.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (inPatrolArea)
        {
            // Follow player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (!inPatrolArea)
        {
            // Cycle through random move points
            transform.position = Vector2.MoveTowards(transform.position, movePoint[current_point], speed * Time.deltaTime);

            if (transform.position == movePoint[current_point])
            {
                int rand_point = Random.Range(0, movePoint.Count - 1);

                // Generate new random value if it is the same as the current
                if (rand_point == current_point)
                {
                    rand_point = Random.Range(0, movePoint.Count - 1);
                }

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
