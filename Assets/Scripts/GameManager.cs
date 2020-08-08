using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RawImage pauseScreen;
    public Sprite[] images;

    private AudioSource audio_source;

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

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ToggleMusic()
    {
        GameObject audio = GameObject.Find("Audio Source");
        audio_source = audio.GetComponent<AudioSource>();

        if (audio_source.volume > 0)
        {
            audio_source.volume = 0;
            GameObject.Find("StopMusic").GetComponent<Image>().sprite = images[1];
        }
        else
        {
            audio_source.volume = 0.5f;
            GameObject.Find("StopMusic").GetComponent<Image>().sprite = images[1];
        }
    }
}
