using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    // Variable used for connection between game and interface
    [SerializeField] GameObject rocketPlayer;
    // Variable for the ship's speed
    [SerializeField] float thrusterForce = 10f;
    // Variable for ships steering force
    [SerializeField] float steeringForce = 10f;
    // Variable for the ship's tilt
    [SerializeField] float tiltingForce = 10f;
    // Boolean used below for accelerating upwards
    bool thrust = false;
    // Boolean used for steering
    bool steer = false;
    // Provides access to the rigidbody
    Rigidbody rb;

    // Awake is called when the script is first loaded
    public void Awake()
    {
        // Accessing the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Function called once per frame, handles tilting
    public void Update()
    {
        Controls();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    /// <summary>
    /// Method for rocket controls
    /// </summary>
    private void Controls()
    {
        // Provides interaction between game and interface
        //rocketPlayer = GameObject.FindGameObjectWithTag("Player");
        rb.GetComponent<Rigidbody>();
        // Sets up control for horizontal movement
        float tilt = Input.GetAxis("Horizontal");

        /// <summary>
        /// If no horizontal user input, keeps rocket steady
        /// </summary>
        if (!Mathf.Approximately(tilt, 0f))
        {
            // Locks rotation
            rb.freezeRotation = true;

            // Line used to stabilize rocket when on ground
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, tilt * tiltingForce * Time.deltaTime)));
        }

        /// <summary>
        /// Check if steering force is applied
        /// </summary>
        if (steer)
        {
            rb.freezeRotation = true;

            // Provides control over steering
            transform.position = transform.position + new Vector3(tilt * steeringForce * Time.deltaTime, 0, 0);
        }

        // Unfreezes rotation
        rb.freezeRotation = false;

        // Sets up control for vertical and horizontal movement
        thrust = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        steer = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow);

    }

    /// <summary>
    /// Handles thrusting
    /// </summary>
    public void FixedUpdate()
    {
        // Key up pushed, rocket go whoosh
        if (thrust)
        {
            // Makes the rocket go up relative to the vertical coordinates of the rocket
            rb.AddForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
        else if (!thrust)
        {
            rb.AddForce(Vector3.up * thrusterForce * Time.deltaTime * -1);
        }

    }
}
