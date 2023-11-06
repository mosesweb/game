using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private Rigidbody rigidBody;
    private readonly float j_Speed = 155.0f;

    private BallSpawner ballspawner;

    [SerializeField]
    public Wings Wings;
    public float m_Speed = 5f;

    // INPUT
    private bool jumpingPressed;
    private bool shootingPressed;

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
            Wings.FlyingWings = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Wings.FlyingWings = true;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            shootingPressed = true;
            ballspawner = GetComponentInChildren<BallSpawner>();

            ballspawner.SpawnBall();
        }
        else
        {
            shootingPressed = false;
        }
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rigidBody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        if (jumpingPressed) { 
        
            rigidBody.AddForce(Vector3.up * j_Speed);
        }
    }
}
