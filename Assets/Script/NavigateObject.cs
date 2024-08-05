using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateObject : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector2 TargetCameraObject;

    private void Update()
    {
        float x = Player.transform.position.x;
        transform.position = new Vector2(x, -4);

        TargetCameraObject = transform.position;
    }
}
