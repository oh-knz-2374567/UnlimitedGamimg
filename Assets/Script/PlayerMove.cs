using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float NormalSpeed;//通常速度
    [SerializeField] float SpeedUpRate;//速度上昇率
    [SerializeField] float JumpForce;//通常ジャンプ力
    [SerializeField] float JumpForceUpRate;//ジャンプ力上昇率
    [SerializeField] float GameOverPosition;//ゲームオーバーになるY軸の座標

    [SerializeField] bool isJumping = true;//接地判定
    [SerializeField] bool isGameOver = false;//ゲームオーバー判定

    [SerializeField] GameObject Player;
    [SerializeField] GameObject FirstPosition;//初期位置

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

　　　　//キー入力一回につき、ジャンプ力が上昇
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping)
        {
            JumpForce += JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }

　　　　//キー入力一回につき、速度が上昇
        if (Input.GetKeyDown(KeyCode.D) & isJumping == true)
        {
            NormalSpeed += SpeedUpRate;
        }
        if (Input.GetKeyDown(KeyCode.A) & isJumping == true)
        {
            NormalSpeed += SpeedUpRate;
        }

        if (GameOverPosition >= Player.transform.position.y)
        {
            isGameOver = true;
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
