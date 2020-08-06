﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    public Transform spawner;
    public GameObject tape;
    public float throwPower;
    public GameObject cam;

    private Rigidbody2D body;
    private Vector2 moveVelocity;
    private bool jump;
    private bool facesRight;
    private float gravity;
    private float waitTime = 0.1f;
    private GameObject underPlayer;
    private bool hasTape;
    private Rigidbody2D tapeBody;
    private bool nearTape;
    private GameObject tapeClone;


    // Start is called before the first frame update
    void Start()
    {
        hasTape = true;
        jump = false;
        facesRight = true;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jump)
        {
            body.AddForce(Vector2.up * jumpSpeed);
            jump = true;
        }
        
        if (Input.GetAxis("Vertical") < 0)
        {
            if (waitTime <= 0)
            {
                if (underPlayer.GetComponent<FallThroughPlatform>() != null)
                {
                    underPlayer.GetComponent<FallThroughPlatform>().ChangeRotation();
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        else if (Input.GetAxis("Vertical") == 0)
        {
            waitTime = 0.5f;
        }
        
        if (!jump)
        { 
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
            moveVelocity = moveInput * movementSpeed;
            body.AddForce(moveVelocity);
        }
        else
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
            moveVelocity = moveInput * movementSpeed / 4;
            body.AddForce(moveVelocity);
        }

        if ((Input.GetAxis("Horizontal") < 0 && facesRight) || (Input.GetAxis("Horizontal") > 0 && !facesRight))
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facesRight = !facesRight;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(hasTape)
            {
                Throw();
            }
            else
            {
                if (nearTape)
                    Pickup();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Button")
        {
            jump = false;
            underPlayer = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tape")
        {
            nearTape = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tape")
        {
            nearTape = false;
        }

        if (other.gameObject.tag == "RoomDoor")
        {
            cam.GetComponent<Movecamera>().moveRight();
            other.GetComponent<BoxCollider2D>().isTrigger = false;
            if (!hasTape)
            {
                Pickup();
            }
        }
    }

    private void Throw()
    {
        tapeClone = Instantiate(tape, spawner.position, spawner.rotation);
        tapeBody = tapeClone.GetComponent<Rigidbody2D>();
        hasTape = false;

        if (Input.GetAxis("Vertical") > 0)
        {
            //Debug.Log("CPLM?");
            tapeBody.AddForce(Vector2.up * throwPower);
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0.6f);
            moveVelocity = moveInput * throwPower;
            tapeBody.AddForce(moveVelocity);
        }
    }

    private void Pickup()
    {
        Destroy(tapeClone);
        hasTape = true;
    }
}
