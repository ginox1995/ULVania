using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMelee : MonoBehaviour
{
    private Animator animator;
    private GameObject contactPoint;

    [SerializeField]
    private float attackRange = 2f;

    [SerializeField]
    private int damage = 2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        contactPoint = transform.Find("ContactPoint").gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Tenemos iniciar ataque
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            contactPoint.transform.position, attackRange);
        foreach(Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<EnemyMovement>().Hurt(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (contactPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(contactPoint.transform.position, attackRange);
    }
}
