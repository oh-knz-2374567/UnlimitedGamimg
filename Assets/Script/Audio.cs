using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip GameOverClip;
    [SerializeField] private AudioSource audiosource;

    // Update is called once per frame
    void Update()
    {
        PlayerMove move = FindObjectOfType<PlayerMove>();

        if (move.isGameOver == true)
        {
            audiosource.clip = GameOverClip;
            audiosource.Play();
        }
    }
}
