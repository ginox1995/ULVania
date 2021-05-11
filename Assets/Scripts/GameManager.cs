using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    RigidBody2D rbHero;
    public Transform hero;
    public float heroSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbHero = hero.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement, rb.velocity.y);

    }
}
