using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuButtons : MonoBehaviour
{
    public GameObject audio;
    public Sprite[] images;

    public void ToggleMusic()
    {
        AudioSource audio_source = audio.GetComponent<AudioSource>();

        if (audio_source.volume > 0)
        {
            audio_source.volume = 0;
            GameObject.Find("StopMusic").GetComponent<Image>().sprite = images[1];
        }
        else
        {
            audio_source.volume = 0.5f;
            GameObject.Find("StopMusic").GetComponent<Image>().sprite = images[0];
        }
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
