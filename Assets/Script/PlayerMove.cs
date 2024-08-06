using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float NormalSpeed;//�ʏ푬�x
    [SerializeField] float SpeedUpRate;//���x�㏸��
    [SerializeField] float JumpForce;//�ʏ�W�����v��
    [SerializeField] float JumpForceUpRate;//�W�����v�͏㏸��
    [SerializeField] float GameOverPosition;//�Q�[���I�[�o�[�ɂȂ�Y���̍��W
    [SerializeField] float TravelDistance;//�i�񂾋���
    [SerializeField] public float CurrentSpeed;//���݂̑��x


    [SerializeField] Vector3 StartPosition;//�����ʒu�̍��W

    [SerializeField] bool isJumping = true;//�ڒn����
    [SerializeField] public bool isGameOver = false;//�Q�[���I�[�o�[����
    [SerializeField] bool isNotMoving = false;//�Q�[���I�[�o�[�ɂ��A����֎~����

    [SerializeField] Text DistanceText;
    [SerializeField] Text DisText01;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject FirstPosition;//�����ʒu

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = FirstPosition.transform.position;

        //�����ʒu���v��
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeed = NormalSpeed;

        //����\�ł���Γ�����
        if (isNotMoving == false)
        {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * NormalSpeed, rb.velocity.y);
        }

        //�L�[���͈��ɂ��A�W�����v�͂��㏸
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping == true & isNotMoving == false)
        {
            JumpForce *= JumpForceUpRate;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = false;
        }

�@�@�@�@//�L�[���͈��ɂ��A���x���㏸
        if (Input.GetKeyDown(KeyCode.D) & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }
        if (Input.GetKeyDown(KeyCode.A) & isJumping == true)
        {
            NormalSpeed *= SpeedUpRate;
        }

        //Y���̂���n�_��艺�ɍs���ƁA�Q�[���I�[�o�[�ƂȂ�A����s�\�ƂȂ�
        if (GameOverPosition >= Player.transform.position.y)
        {
            isGameOver = true;
            isNotMoving = true;
        }

        //�i�񂾋������e�L�X�g�\���i�������ʂ܂Łj
        TravelDistance = (transform.position.x -StartPosition.x);
        DistanceText.text = "����: " + TravelDistance.ToString("F1") + "m";
        DisText01.text = "�i�񂾋���:�@�@�@�@�@ " + TravelDistance.ToString("F1") + "m";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
