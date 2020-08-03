using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D body;
    private UnityEngine.Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 moveInput = new UnityEngine.Vector2(Input.GetAxis("Horizontal"), 0);
        moveVelocity = moveInput * movementSpeed;
    }

    private void FixedUpdate()
    {
        body.AddForce(moveVelocity * Time.fixedDeltaTime);
    }
}
