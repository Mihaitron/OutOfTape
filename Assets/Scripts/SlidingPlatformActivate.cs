using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatformActivate : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public GameObject activator;
    public float speed;

    private Lever lever;
    private bool leverStatus;
    private GroundButton button;
    private bool buttonStatus;
    private bool isLever;
    private bool moovingB = true;
    private bool moovingA = false;
    private bool move = false;
    private float waitTime = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        if (activator.tag == "Lever")
        {
            lever = activator.GetComponent<Lever>();
            leverStatus = lever.active;
            isLever = true;
        }
        else if (activator.tag == "Button")
        {
            button = activator.GetComponent<GroundButton>();
            buttonStatus = button.active;
            isLever = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLever)
        {

            if (leverStatus != lever.active)
            {

                leverStatus = lever.active;
                if (leverStatus)
                {
                    move = true;
                }
                else
                {
                    move = false;
                }
            }
        }
        else
        {
            if (buttonStatus != button.active)
            {
                buttonStatus = button.active;
                if (buttonStatus)
                {
                    move = true;
                }
                else
                {
                    move = false;
                }
            }
        }

        if (move)
        {
            Debug.Log(move);
            if (moovingB)
            {

                transform.position = Vector3.MoveTowards(transform.position, positionB.position, speed);
                if (transform.position == positionB.position)
                {
                    if (waitTime <= 0)
                    {
                        moovingB = false;
                        moovingA = true;
                        waitTime = 0.7f;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            else if (moovingA)
            {
                transform.position = Vector3.MoveTowards(transform.position, positionA.position, speed);
                if (transform.position == positionA.position)
                {
                    if (waitTime <= 0)
                    {
                        moovingA = false;
                        moovingB = true;
                        waitTime = 0.7f;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                };
            }
        }
    }
}
