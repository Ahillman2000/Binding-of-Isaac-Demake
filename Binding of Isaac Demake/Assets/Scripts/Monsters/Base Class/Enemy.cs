using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float health_ = 0;
    protected int damage_ = 0;

    protected virtual void Start() {}

    protected virtual void Update()
    {
        Movement();
        Attack();
    }

    protected virtual void Movement() {}

    protected virtual void Attack() {}

    protected virtual void Die() {}
}
