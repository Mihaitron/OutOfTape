using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active;
    public Sprite leverUp;
    public Sprite leverDown;

    public void ChangeActive()
    {
        active = !active;
        if (active)
        {
            GetComponent<SpriteRenderer>().sprite = leverDown;
        }
        if (!active)
        {
            GetComponent<SpriteRenderer>().sprite = leverUp;
        }
    }
}
