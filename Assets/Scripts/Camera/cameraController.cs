using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
[] Add camera focus on objects on click
    [] Fix rotation to focus on center of playfield.
[] Fix Mouse drag
[] Refactor camera pan limits with Mathf.clamp()
[] Fine tune camera motion rate and easing
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
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
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
        HandleMouseInput();
        HandleMovementInput();
    }

    void HandleMouseInput()
    {
        if(Input.GetMouseButtonDown(0)) //If left mouse is clicked
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero); // create a 2D plane with vectors up and down.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Cast a ray from the camera to the mouse position.
            float entry; //Used to track the entry point of the Raycast.
            if(plane.Raycast(ray, out entry)) //Perform raycast on plane.
            {
                dragStartPosition = ray.GetPoint(entry); //use ths point as the start postion of the mouse click.
            }
        }

        if(Input.GetMouseButtonDown(0)) //If the mouse is still held down.
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero); // Perform a second raycast.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Make a second plane
            float entry; 
            if(plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry); //Set the entry point to the current postion of the drag.
                newPosition = transform.position + dragStartPosition - dragCurrentPosition; //subtract the start from the current position and add it to the transform to update the camera's position.
            }
        }
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
