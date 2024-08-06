using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float NormalSpeed;//通常速度
    [SerializeField] float SpeedUpRate;//速度上昇率
    [SerializeField] float JumpForce;//通常ジャンプ力
    [SerializeField] float JumpForceUpRate;//ジャンプ力上昇率
    [SerializeField] float GameOverPosition;//ゲームオーバーになるY軸の座標
    [SerializeField] float TravelDistance;//進んだ距離
    [SerializeField] public float CurrentSpeed;//現在の速度


    [SerializeField] Vector3 StartPosition;//初期位置の座標

    [SerializeField] bool isJumping = true;//接地判定
    [SerializeField] public bool isGameOver = false;//ゲームオーバー判定
    [SerializeField] bool isNotMoving = false;//ゲームオーバーにつき、操作禁止判定

    [SerializeField] Text DistanceText;
    [SerializeField] Text DisText01;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject FirstPosition;//初期位置

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = FirstPosition.transform.position;

        //初期位置を計測
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeed = NormalSpeed;

        //操作可能であれば動ける
        if (isNotMoving == false)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * NormalSpeed, rb.velocity.y);
        }

        //キー入力一回につき、ジャンプ力が上昇
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping == true & isNotMoving == false)
        {
            JumpForce *= JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }

　　　　//キー入力一回につき、速度が上昇
        if (Input.GetKeyDown(KeyCode.D) & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }
        if (Input.GetKeyDown(KeyCode.A) & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }

        //Y軸のある地点より下に行くと、ゲームオーバーとなり、操作不可能となる
        if (GameOverPosition >= Player.transform.position.y)
        {
            isGameOver = true;
            isNotMoving = true;
        }

        //進んだ距離をテキスト表示（小数第一位まで）
        TravelDistance = (transform.position.x -StartPosition.x);
        DistanceText.text = "距離: " + TravelDistance.ToString("F1") + "m";
        DisText01.text = "進んだ距離:　　　　　 " + TravelDistance.ToString("F1") + "m";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
