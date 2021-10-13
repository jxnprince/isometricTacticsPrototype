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

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform cameraTransform;
    public Transform followTransform;

    public float rotationAmount;
    public float movementTime;
    public float movementSpeed;
    public float normalSpeed, fastSpeed;
    public float maxZoom, minZoom;

    public Vector3 newPosition;
    public Vector3 ogPosition;
    public Vector3 zoomAmount;
    public Vector3 newZoom;
    public Vector3 ogZoom;
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    public Quaternion newRotation;
    public Quaternion ogRotation;


    void Start()
    {
        instance = this;

        newPosition = transform.position; //Prevents transform from defaulting to 0
        ogPosition = transform.position; //Original camera placement

        newRotation = transform.rotation; //Current camera rotation
        ogRotation = transform.rotation; //Original camera rotation

        newZoom = cameraTransform.localPosition; //Current camera zoom
        ogZoom = cameraTransform.localPosition; //original camera zoom
        maxZoom = -13f;
        minZoom = -41f;
    }

    void Update()
    {
        if(followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            HandleMouseInput();
            HandleMovementInput();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followTransform = null;
        }
    }

    void HandleMouseInput()
    {  
        if(Input.mouseScrollDelta.y != 0 && newZoom.z >= minZoom - 6f && newZoom.z <= maxZoom)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
        if(Input.GetMouseButtonDown(0)) //If left mouse is clicked
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero); // create a 2D plane with vectors up and down.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Cast a ray from the camera to the mouse position.
            float entry; //Used to track the entry point of the Raycast.
            if(plane.Raycast(ray, out entry)) //Perform raycast on plane.
            {
                dragStartPosition = ray.GetPoint(entry); //use ths point as the start postion of the drag.
            }
        }

        if(Input.GetMouseButtonDown(0) ) //If the mouse is still held down.
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

        if(Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
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
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) //Supports `WASD` & arrow keys
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

        // //Camera Rotation
        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= (Quaternion.Euler(Vector3.up * rotationAmount));
        }
        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= (Quaternion.Euler(Vector3.up * -rotationAmount));
        }

        //Camera Zoom
        if(Input.GetKey(KeyCode.R) && newZoom.z <= maxZoom)
        {
            Mathf.Clamp(newZoom.y, 9.75f, 40f);
            newZoom += zoomAmount;
        }
        if(Input.GetKey(KeyCode.F) && newZoom.z >= minZoom - 6f)
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
        // void LateUpdate()
        // {
            
        // }
}
