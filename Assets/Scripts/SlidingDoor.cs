using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
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
    //private bool currentPosition = false;
    private bool moovingB = false;
    private bool moovingA = false;

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
    void Update()
    {
        if (isLever)
        {

            if (leverStatus != lever.active)
            {

                leverStatus = lever.active;
                if (leverStatus)
                {
                    moovingB = true;
                    moovingA = false;
                }
                else
                { 
                    moovingB = false;
                    moovingA = true;
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
                    moovingB = true;
                    moovingA = false;
                }
                else
                {
                    moovingB = false;
                    moovingA = true;
                }
            }
        }

        if (moovingB)
        {

            transform.position = Vector3.MoveTowards(transform.position, positionB.position, speed);
            if (transform.position == positionB.position)
                moovingB = false;
        }
        else if (moovingA)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionA.position, speed);
            if (transform.position == positionA.position)
                moovingA = false;
        }
    }
}
