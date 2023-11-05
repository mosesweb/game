using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private Rigidbody rigidBody;
    public float m_Speed = 5f;
    private bool jumpingPressed;
    private readonly float j_Speed = 155.0f;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidBody = GetComponent<Rigidbody>();
        rigidBody = gameObject.GetComponent<Rigidbody>();

}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpingPressed = true;
        } else
        {
            jumpingPressed = false;
        }
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rigidBody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        if (jumpingPressed && isGrounded) { 
        
            rigidBody.AddForce(Vector3.up * j_Speed);
        }
    }
}
