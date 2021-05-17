using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostMovement : MonoBehaviour
{

    public Transform gost;
    public float gostSpeed;
    public float gostJumpSpeed;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    Rigidbody2D rbGost;
    Animator animmatorGost;
    SpriteRenderer srGost;
    CapsuleCollider2D colliderGost;
    //private bool isRunning = false;
    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        rbGost = gost.GetComponent<Rigidbody2D>();
        animmatorGost = gost.GetComponent<Animator>();
        srGost = gost.GetComponent<SpriteRenderer>();
        colliderGost = gost.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (srGost.isVisible)
        {
            movement = Input.GetAxisRaw("Horizontal");
            if (movement < 0)
            {
                srGost.flipX = true;
                
            }
            else if (movement > 0)
            {
                srGost.flipX = false;
                
            }

            rbGost.velocity = new Vector2(movement * gostSpeed, rbGost.velocity.y);

            if (IsJumping()) // puede ser un or (if (!isJumping() && !isJumping <--- no esta tan bien
            {
                animmatorGost.SetBool("isJumping", false);
            }

            if (//!IsJumping() && 
                Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

            if (rbGost.velocity.y < 0)
            {
                // Esta cayendo
                rbGost.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rbGost.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rbGost.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            }
    }

    private void Jump()
    {
        animmatorGost.SetBool("isJumping", true);
        animmatorGost.SetTrigger("jump");
        rbGost.velocity = new Vector2(rbGost.velocity.x, gostJumpSpeed);
    }

    private bool IsJumping()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            colliderGost.bounds.center,
            Vector2.down,
            colliderGost.bounds.extents.y + 0.2f
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

        Debug.DrawRay(colliderGost.bounds.center,
            Vector2.down * (colliderGost.bounds.extents.y + 0.2f),
            color);
    }
}
