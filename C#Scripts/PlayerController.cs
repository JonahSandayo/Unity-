using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float jumpForce = 10f;
private Rigidbody2D rb;
private BoxCollider2D col;

private bool isGrounded = true;
private bool doubleJump = true;

private Vector2 originalColliderSize;
private Vector2 crouchColliderSize = new Vector2(1f, 0.5f); 

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<BoxCollider2D>();
    originalColliderSize = col.size;
}

void Update()
{
    // ジャンプ
    if (Input.GetKeyDown(KeyCode.W))
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
        }
    }

    // しゃがみ
    if (Input.GetKey(KeyCode.S))
    {
        col.size = crouchColliderSize;
        transform.localScale = new Vector3(1f, 0.5f, 1f);
    }
    else
    {
        col.size = originalColliderSize;
        transform.localScale = Vector3.one;
    }
}

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
        doubleJump = true;
    }
}

}
