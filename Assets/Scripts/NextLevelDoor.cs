using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
    public int nextLevel;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager");
    }

    public void NextLevel()
    {
        gameManager.GetComponent<GameManager>().ChangeScene(nextLevel);
    }
}
