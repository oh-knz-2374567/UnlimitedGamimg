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

    private void Start()
    {
       GameOverUI.SetActive(false);
       MonitorUI.SetActive(false);
       GameOverText.SetActive(false);
       DisText01.SetActive(false);
    }

    private void Update()
    {
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
