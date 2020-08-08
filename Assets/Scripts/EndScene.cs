using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    private void Start()
    {
        GameObject manager = GameObject.Find("Game Manager");

        if (manager != null)
            manager.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
