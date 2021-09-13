using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
=====
[] Add camera maximum position limits
[X] Add camera reset
*/

public class cameraController : MonoBehaviour
{
    //Items surfaced in the inspector
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;

    public Vector3 newPosition;
    public Vector3 ogPosition;

    void Start()
    {
        newPosition = transform.position; //Prevents transform from defaulting to 0
        ogPosition = transform.position; //Prevents transform from defaulting to 0
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput() //Handles all camera movement input from player
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) //Holding either shift enables preset higher camera speed
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //Supports `WASD` & Arrow Keys
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.Tab)) //Resets camera to original position and rotation
        {
            newPosition = (ogPosition);

        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); //Linear interpolation between original camera postion to new position over specified time

    }
}
