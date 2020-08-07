using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public GameObject upPossition;
    public bool active;

    private bool tapeCol;
    private bool playerCol;

    private void Start()
    {
        active = false;
        tapeCol = false;
        playerCol = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tape")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                tapeCol = false;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                playerCol = false;
            }
        }

        active = tapeCol || playerCol;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tape")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                tapeCol = true;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                playerCol = true;
            }
        }

        active = tapeCol || playerCol;
    }

    public void setTapeCollision(bool isActive)
    {
        tapeCol = isActive;
    }
}
