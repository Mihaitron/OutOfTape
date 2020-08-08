using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RawImage pauseScreen;

    private AudioSource audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.gameObject.SetActive(!pauseScreen.gameObject.active);
            
            if (pauseScreen.gameObject.active)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ToggleMusic()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        if (audio.volume > 0)
            audio.volume = 0;
        else
            audio.volume = 0.5f;
    }
}
