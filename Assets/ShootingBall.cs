using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBall : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float m_Speed = 103f;
    public GameObject player; // Reference to your player character.

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            if (player != null) { 
            // Calculate the direction towards the player.
            Vector3 playerForward = player.transform.forward;

            // Apply force to the sphere to move it in that direction.
            m_Rigidbody.AddForce(playerForward * m_Speed);
        }
    }
}
