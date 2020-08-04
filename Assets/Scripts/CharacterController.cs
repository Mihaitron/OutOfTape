using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;

    private Rigidbody2D body;
    private UnityEngine.Vector2 moveVelocity;
    private bool jump;
    private bool facesRight;

    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        facesRight = true;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jump)
        {
            body.AddForce(UnityEngine.Vector2.up * jumpSpeed);
            Debug.Log(body.velocity);
            jump = true;
        }
        
        if (!jump)
        { 
            UnityEngine.Vector2 moveInput = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), 0);
            moveVelocity = moveInput * movementSpeed;
            body.AddForce(moveVelocity * Time.fixedDeltaTime);
        }
        else
        {
            UnityEngine.Vector2 moveInput = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), 0);
            moveVelocity = moveInput * movementSpeed / 4;
            body.AddForce(moveVelocity * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
    }
}
