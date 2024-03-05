using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField]private float MovementSpeed = 10f;
    [SerializeField]private float JumpHeight = 8f;
    [SerializeField]private Rigidbody2D PlayerRB;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;

    // Update is called once per frame
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpHeight);
        }
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity = new Vector2(horizontal * MovementSpeed, PlayerRB.velocity.y);
    }
}
