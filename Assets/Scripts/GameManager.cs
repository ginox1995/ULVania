using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform hero;
    public float heroSpeed;
    public float heroJumpSpeed;

    Rigidbody2D rbHero;
    Animator animmatorHero;
    SpriteRenderer srHero;
    CapsuleCollider2D colliderHero;
    //private bool isRunning = false;

    void Start()
    {
        rbHero = hero.GetComponent<Rigidbody2D>();
        animmatorHero = hero.GetComponent<Animator>();
        srHero = hero.GetComponent<SpriteRenderer>();
        colliderHero = hero.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsJumping()) Debug.Log("Salta!");


        float movement = Input.GetAxis("Horizontal");
        if (movement < 0)
        {
            srHero.flipX = true;
            animmatorHero.SetBool("isRunning", true);
        }
        else if (movement > 0)
        {
            srHero.flipX = false;
            animmatorHero.SetBool("isRunning", true);
        }
        else
        {
            animmatorHero.SetBool("isRunning", false);
        }
        rbHero.velocity = new Vector2(movement * heroSpeed, rbHero.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rbHero.velocity = new Vector2(rbHero.velocity.x, heroJumpSpeed);
    }

    private bool IsJumping()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            colliderHero.bounds.center,
            Vector2.down,
            colliderHero.bounds.extents.y + 0.1f
        );

        DebugJumpRay(hit);

        return !hit;
    }

    private void DebugJumpRay(RaycastHit2D hit)
    {
        Color color;
        if (hit)
        {
            color = Color.red;
        }
        else
        {
            color = Color.white;
        }

        Debug.DrawRay(colliderHero.bounds.center,
            Vector2.down * (colliderHero.bounds.extents.y + 0.1f),
            color);
    }
}