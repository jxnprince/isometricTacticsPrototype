using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
=====
[] Fix rotation
[] Refactor camera pan limits with Mathf.clamp()
[] Add camera focus
*/

public class cameraController : MonoBehaviour
{
    //Items surfaced in the inspector
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;

    public Vector3 zoomAmount;
    public Vector3 newPosition;
    public Vector3 ogPosition;
    public Vector3 newZoom;
    public Vector3 ogZoom;

    public Quaternion newRotation;
    public Quaternion ogRotation;

    public Transform cameraTransform;

    void Start()
    {
        newPosition = transform.position; //Prevents transform from defaulting to 0
        ogPosition = transform.position; //Original camera placement

        newRotation = transform.rotation; //Current camera rotation
        ogRotation = transform.rotation; //Original camera rotation

        newZoom = cameraTransform.localPosition; //Current camera zoom
        ogZoom = cameraTransform.localPosition; //original camera zoom
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput() //Handles all camera movement input from player
    {
        if(Input.GetKey(KeyCode.LeftShift) ) //Holding shift enables preset higher camera speed
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

        //Camera Panning
        if((Input.GetKey(KeyCode.W))) //Supports `WASD` & Arrow Keys
        {
            if(newPosition[1] < 45.8f) //Upper camera limit
            {
            newPosition += (transform.forward * movementSpeed);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(newPosition[1] > 43.4f) //Lower camera limit
            {
            newPosition += (transform.forward * -movementSpeed);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(newPosition[0] < -40f) //Right camera limit
            {
            newPosition += (transform.right * movementSpeed);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(newPosition[0] > -50f) //Left camera limit
            {
            newPosition += (transform.right * -movementSpeed);
            }
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
        if(Input.GetKey(KeyCode.T) && newZoom[1] >= -25 && newZoom[2] <= 25)
        {
            newZoom += zoomAmount;
        }
        if(Input.GetKey(KeyCode.R)&& newZoom[1] <= 250 && newZoom[2] >= -250)
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

        //Render postion, rotaion, and zoom movements
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); //Linear interpolation between original camera postion to new position over specified time.
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); //Linear interpolation between original camera rotation to a new rotation over specified time.
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);//Linear interpolation between original camera zoom to a new zoom level over specified time.
    }
}
