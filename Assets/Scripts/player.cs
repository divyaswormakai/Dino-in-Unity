using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jump = 150f;
    Rigidbody2D rb;
    bool onGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            print("ASDF");
            rb.AddForce(Vector2.up * jump * Time.deltaTime * rb.mass * rb.gravityScale,ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * jump * Time.deltaTime * rb.mass * rb.gravityScale, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "ground")
        {
            onGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "ground")
        {
            onGround = true;
        }
    }
}
