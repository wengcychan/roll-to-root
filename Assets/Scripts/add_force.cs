using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_force : MonoBehaviour
{
	Rigidbody2D rb;
    Vector2 force;
    GameObject user_input;

    void modify_physics(Rigidbody2D rb)
    {
        if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 1)
            rb.drag = 5;
        else if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 0.1)
            rb.drag = 100;
        else
            rb.drag = 0.35f;
        if (Mathf.Abs(rb.angularVelocity) < 20)
            rb.angularDrag = 10;
        else
            rb.angularDrag = 0.35f;
    }

    void Start()
    {
        user_input = GameObject.Find("user_input");
        // Debug.Log("Active the balls!");
        rb = gameObject.GetComponent<Rigidbody2D>();
        force = user_input.GetComponent<user_input>().firePos.up * user_input.GetComponent<user_input>().shoot_force;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        modify_physics(rb);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this.GetComponent<AudioSource>().Play();
    }
}