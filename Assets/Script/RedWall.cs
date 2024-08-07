using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedWall : MonoBehaviour
{
    [SerializeField] Transform Player; //プレイヤー

    [SerializeField] float Speed; //速度
    [SerializeField] float EnemySpeed; //追いかける速度
    [SerializeField] float SpeedRate; //速度にかける倍率
    [SerializeField] float DelayTime;//遅延速度
    [SerializeField] float ElapsedTime;//経過時間

    private void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime >= DelayTime)
        {
            //プレイヤーの速度を計測
            PlayerMove move = FindObjectOfType<PlayerMove>();
            Speed = move.CurrentSpeed;

            //プレイヤーの速度をもとにエネミーの速度を決める
            EnemySpeed = Speed * SpeedRate;

            Vector2 direction = Player.position - transform.position;
            direction.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemySpeed * Time.deltaTime);
        }
    }
}

