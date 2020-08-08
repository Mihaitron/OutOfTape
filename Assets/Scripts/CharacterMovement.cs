using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 40f;
    public Transform spawner;
    public GameObject tape;
    public float throwPower;
    public GameObject cam;
    public TrailRenderer trailRender;
    public Animator animator;

    private float horizontalMove = 0f;
    private bool jump = false;
    private Vector2 moveVelocity;
    private float waitTime = 0.1f;
    private GameObject underPlayer;
    private bool hasTape;
    private Rigidbody2D tapeBody;
    private bool nearTape;
    private bool nearLever;
    private GameObject tapeClone;
    private Lever lever;

    void Start()
    {
        hasTape = true;
        nearLever = false;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("is_jumping", true);
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

        if (Input.GetButtonDown("Fire1"))
        {
            if (!nearLever)
            {
                if (hasTape)
                {
                    Throw();
                    trailRender.enabled = true;
                }
                else
                {
                    if (nearTape)
                    {
                        Pickup();
                        trailRender.Clear();
                        trailRender.enabled = false;
                    }
                }
            }
            else
            {
                lever.ChangeActive();
            }
        }

        if (Input.GetButtonDown("Fire2") && !hasTape)
        {
            transform.position = new Vector3(tapeClone.transform.position.x, tapeClone.transform.position.y + 1, tapeClone.transform.position.z);
            Pickup();
            trailRender.Clear();
            trailRender.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
        animator.SetBool("is_jumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Button" || collision.gameObject.tag == "Tape")
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

        if (other.gameObject.tag == "Lever")
        {
            nearLever = true;
            lever = other.GetComponent<Lever>();
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
                trailRender.Clear();
                trailRender.enabled = false;
            }

            Tutorial tutorial = other.gameObject.GetComponent<Tutorial>();
            if (tutorial != null)
            {
                int index = Int16.Parse(other.gameObject.name);

                StartCoroutine(tutorial.ChangeTutorial(index));
            }
        }

        if (other.gameObject.tag == "LevelDoor")
        {
            other.gameObject.GetComponent<NextLevelDoor>().NextLevel();
        }

        if (other.gameObject.tag == "Lever")
        {
            nearLever = false;
            lever = null;
        }
    }

    private void Throw()
    {
        tapeClone = Instantiate(tape, spawner.position, spawner.rotation);
        tapeBody = tapeClone.GetComponent<Rigidbody2D>();
        hasTape = false;

        animator.Play("Terry_Throw");
        animator.SetBool("has_cassette", false);

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

        animator.SetBool("is_throwing", false);
    }

    private void Pickup()
    {
        Destroy(tapeClone);
        hasTape = true;
        animator.SetBool("has_cassette", true);
    }
}
