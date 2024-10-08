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
    [SerializeField] float CurrentTravelDistance;//現在の進んだ距離
    [SerializeField] float HighTravelDistance;//今まで進んだ最大距離
    [SerializeField] public float CurrentSpeed;//現在の速度


    [SerializeField] Vector3 StartPosition;//初期位置の座標

    [SerializeField] bool isJumping = true;//接地判定
    [SerializeField] public bool isGameOver = false;//ゲームオーバー判定
    [SerializeField] bool isNotMoving = false;//ゲームオーバーにつき、操作禁止判定

    [SerializeField] Text DistanceText;//距離を表示するテキスト
    [SerializeField] Text DisText01;//ゲームオーバー時に距離を表示するスクリプト
    [SerializeField] Text DisText02;//ゲームオーバー時点の最大距離を表示するスクリプト
    [SerializeField] Transform Player;//プレイヤー
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


            //キャラクターの進行方向によって向きを変える
            if (move < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (move > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        //キー入力一回につき、ジャンプ力が上昇
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping == true & isNotMoving == false)
        {
            JumpForce *= JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }

　　　　//キー入力一回につき、速度が上昇
        if (Input.GetKey(KeyCode.D) & Player.transform.position.y < 3 & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }
        if (Input.GetKey(KeyCode.A) & Player.transform.position.y < 3 & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }

        //Y軸のある地点より下に行くと、ゲームオーバーとなり、操作不可能となる
        if (GameOverPosition >= Player.transform.position.y)
        {
            isGameOver = true;
            isNotMoving = true;

            CurrentTravelDistance = TravelDistance;
        }

        //進んだ距離をテキスト表示（小数第一位まで）
        if (isGameOver == false)
        {
            TravelDistance = (transform.position.x - StartPosition.x);
        }

        DistanceText.text = "距離: " + TravelDistance.ToString("F1") + "m";
        DisText01.text = "進んだ距離:　　　　　 " + CurrentTravelDistance.ToString("F1") + "m";
        if (CurrentTravelDistance > HighTravelDistance)
        {
            HighTravelDistance = CurrentTravelDistance;
        }
        DisText02.text = "最高距離:             " + HighTravelDistance.ToString("F1") + "m";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   //速度が速くなると、ジャンプをしていなくても飛ぶので、高さを設けて判定を取る
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
