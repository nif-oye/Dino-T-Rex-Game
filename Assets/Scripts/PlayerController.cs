using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 14f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool jumpHeld = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.gameStarted && isGrounded && (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) || Input.GetMouseButton(0)))
        {
            jumpHeld = true;
        }
        else
        {
            jumpHeld = false;
        }

        if (jumpHeld)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
