using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedWall : MonoBehaviour
{
    [SerializeField] Transform Player; //�v���C���[

    [SerializeField] float Speed; //���x
    [SerializeField] float EnemySpeed; //�ǂ������鑬�x
    [SerializeField] float SpeedRate; //���x�ɂ�����{��
    [SerializeField] float DelayTime;//�x�����x
    [SerializeField] float ElapsedTime;//�o�ߎ���

    private void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime >= DelayTime)
        {
            //�v���C���[�̑��x���v��
            PlayerMove move = FindObjectOfType<PlayerMove>();
            Speed = move.CurrentSpeed;

            //�v���C���[�̑��x�����ƂɃG�l�~�[�̑��x�����߂�
            EnemySpeed = Speed * SpeedRate;

            Vector2 direction = Player.position - transform.position;
            direction.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemySpeed * Time.deltaTime);
        }
    }
}

