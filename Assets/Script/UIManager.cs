using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject MonitorUI;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject DisText01;
    [SerializeField] Text FPSText;

    private float deltaTime = 0.0f;
    private float TimeLeft = 0.0f;
    private float UpdateIntarval = 0.1f;

    private void Start()
    {
        TimeLeft = UpdateIntarval;

       GameOverUI.SetActive(false);
       MonitorUI.SetActive(false);
       GameOverText.SetActive(false);
       DisText01.SetActive(false);
    }

    private void Update()
    {
        //FPS表記において0.1秒の遅延をいれ、正確なFPSを表示させる
        TimeLeft -= Time.deltaTime;
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (TimeLeft <= 0.0f)
        {
            // FPSを計算
            float fps = 1.0f / deltaTime;
            // テキストにFPSを表示
            FPSText.text = string.Format("{0:0.} FPS", fps);

            deltaTime = 0.0f;
            TimeLeft = UpdateIntarval;
        }



        PlayerMove move = FindObjectOfType<PlayerMove>();
        if (move.isGameOver == true)
        {
            GameOverUI.SetActive(true);
            MonitorUI.SetActive(true);
            GameOverText.SetActive(true);
            DisText01.SetActive(true);
        }
    }
}
