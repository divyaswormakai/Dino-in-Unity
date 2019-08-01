using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jump = 170f;
    Rigidbody2D rb;
    bool onGround = false;
    public bool gameOver = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gameOver)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && onGround)
            {
                Vector2 force = Vector2.up * jump * Time.deltaTime * rb.mass * rb.gravityScale;
                if (force.y > 275f || force.y < 225)
                {
                    force.y = 250f;
                }
                rb.AddForce(force, ForceMode2D.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.AddForce(Vector2.down * jump * Time.deltaTime * rb.mass * rb.gravityScale, ForceMode2D.Impulse);
            }
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "ground")
        {
            onGround = true;
        }
        else                                //for collision with enemies.
        {
            gameOver = true;
            print("Collision detected");
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
