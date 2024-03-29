﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{

    public Transform positionA;
    public Transform positionB;
    public float speed;

    private bool moovingB = true;
    private bool moovingA = false;
    private float waitTime = 0.7f;

    void FixedUpdate()
    {
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
            }
        }
    }
}
