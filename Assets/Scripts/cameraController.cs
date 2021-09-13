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
    public Transform cameraTransform;
    //Items surfaced in the inspector
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Vector3 ogPosition;
    public Quaternion newRotation;
    public Quaternion ogRotation;
    public Vector3 newZoom;
    public Vector3 ogZoom;

    void Start()
    {
        newPosition = transform.position; //Prevents transform from defaulting to 0
        ogPosition = transform.position; //Keeps track of original camera placement

        newRotation = transform.rotation; //Keeps track of current camera rotation
        ogRotation = transform.rotation; //Keeps track of original camera rotation

        newZoom = cameraTransform.localPosition; //Keeps track of current camera zoom
        ogZoom = cameraTransform.localPosition; //Keeps track of original camera zoom
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

        //Camera Panning
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
        //Camera Rotation
        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= (Quaternion.Euler(Vector3.up * rotationAmount));
        }
        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= (Quaternion.Euler(Vector3.up * -rotationAmount));
        }
        //Camera Zoom
        if(Input.GetKey(KeyCode.T))
        {
            newZoom += zoomAmount;
        }
        if(Input.GetKey(KeyCode.R))
        {
            newZoom -= zoomAmount;
        }
        //Resets camera to original position and rotation
        if(Input.GetKey(KeyCode.Tab))
        {
            newPosition = ogPosition;
            newRotation = ogRotation;
            newZoom = ogZoom;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); //Linear interpolation between original camera postion to new position over specified time.
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); //Linear interpolation between original camera rotation to a new rotation over specified time.
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);//Linear interpolation between original camera zoom to a new zoom level over specified time.
    }
}
