using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject WayPage;

    private void Start()
    {
        WayPage.SetActive(false);
    }

    public void WayPageOpen()
    {
        WayPage.SetActive(true);
    }
}
