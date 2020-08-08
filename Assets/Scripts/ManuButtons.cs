using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuButtons : MonoBehaviour
{
    public AudioSource audio;

    public void ToggleMusic()
    {
        if (audio.volume > 0)
            audio.volume = 0;
        else
            audio.volume = 0.5f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
