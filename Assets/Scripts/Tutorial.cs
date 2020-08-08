using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] canvases;

    public IEnumerator ChangeTutorial(int canvas)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(false);
        }

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < canvases.Length; i++)
        {
            if (i == canvas)
                canvases[i].SetActive(true);
            else
                canvases[i].SetActive(false);
        }
    }
}
