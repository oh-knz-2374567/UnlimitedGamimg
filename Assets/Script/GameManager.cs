using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool OnPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && OnPause == false)
        {
            Time.timeScale = 0;
        }
    }
}
