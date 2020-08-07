using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public GameObject upPossition;
    public bool active;
    public Sprite buttonUp;
    public Sprite buttonDown;

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
                GetComponent<SpriteRenderer>().sprite = buttonUp;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                playerCol = false;
                GetComponent<SpriteRenderer>().sprite = buttonUp;
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
                GetComponent<SpriteRenderer>().sprite = buttonDown;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > upPossition.transform.position.y)
            {
                playerCol = true;
                GetComponent<SpriteRenderer>().sprite = buttonDown;
            }
        }

        active = tapeCol || playerCol;
    }

    public void setTapeCollision(bool isActive)
    {
        tapeCol = isActive;
    }
}
