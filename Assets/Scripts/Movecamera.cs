using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{

    public float speed;
    public float dist;

    private Vector3 dest;
    private bool ongoing;

    private void Start()
    {
        ongoing = false;
    }

    private void Update()
    {
        if (ongoing)
            transform.position = Vector3.MoveTowards(transform.position, dest, speed);

        if (ongoing && transform.position.x >= dest.x && transform.position.y >= dest.y)
            ongoing = false;
    }

    public void moveRight()
    {
        dest = new Vector3(transform.position.x + dist, transform.position.y, transform.position.z);

     
        ongoing = true;
    }
}
