using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float NormalSpeed;
    [SerializeField] float SpeedUpRate;
    [SerializeField] float JumpForce;
    [SerializeField] float JumpForceUpRate;
    [SerializeField] bool isJumping = true;

    [SerializeField] GameObject FirstPosition;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = FirstPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2( move * NormalSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)&& isJumping)
        {
            JumpForce += JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
