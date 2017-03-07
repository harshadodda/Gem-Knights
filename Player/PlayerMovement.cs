using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How fast the character can move
    public int movementSpeed = 10;
    public int rotateSpeed = 100;
    public int jumpHeight = 400;

    // Players RigidBody
    private Rigidbody playerRB;
    float distToGround;

    void Start()
    {
        // Gets the RigidBody
        playerRB = GetComponent<Rigidbody>();

        //
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
    void Update()
    {

        
        // Move forward
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * movementSpeed));

        }

        // Move backward
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * (Time.deltaTime * movementSpeed));
        }

        // Rotate left
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        // Rotate right
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        // Jump upwards by adding force and check if it is on the ground
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            playerRB.AddForce(transform.up * (jumpHeight));
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Left Click");
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Right Click");
        }
    }

    
    // Checks if the collider is on the ground
   bool IsGrounded(){
    return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1);
 }


}