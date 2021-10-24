using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float speed = 200.0F;
    public float nextWaypointDistance = 3.0F;

    Path path_;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0, 0.5F);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path path)
    {
        if(!path.error)
        {
            path_ = path;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path_ == null)
            return;

        if(currentWaypoint >= path_.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } 
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path_.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path_.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
