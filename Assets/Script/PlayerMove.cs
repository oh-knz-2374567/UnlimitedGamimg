using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float NormalSpeed;//�ʏ푬�x
    [SerializeField] float SpeedUpRate;//���x�㏸��
    [SerializeField] float JumpForce;//�ʏ�W�����v��
    [SerializeField] float JumpForceUpRate;//�W�����v�͏㏸��
    [SerializeField] float GameOverPosition;//�Q�[���I�[�o�[�ɂȂ�Y���̍��W

    [SerializeField] bool isJumping = true;//�ڒn����
    [SerializeField] bool isGameOver = false;//�Q�[���I�[�o�[����

    [SerializeField] GameObject Player;
    [SerializeField] GameObject FirstPosition;//�����ʒu

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

�@�@�@�@//�L�[���͈��ɂ��A�W�����v�͂��㏸
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping)
        {
            JumpForce += JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }

�@�@�@�@//�L�[���͈��ɂ��A���x���㏸
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
