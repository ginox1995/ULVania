using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    Spawn, Walk, Destroy
}

public class EnemyMovement : MonoBehaviour
{
    private EnemyState state;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private int health = 10;

    [SerializeField]
    private float speed = 4f;

    private void Start()
    {
        state = EnemyState.Walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (state == EnemyState.Walk)
        {
            Walk();
        }
    }

    private void Walk()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y); 
    }

    private void Die()
    {
        animator.SetTrigger("destroy");
        state = EnemyState.Destroy;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }
}
