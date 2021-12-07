using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camera;
    public CharacterController controller;
    
    public float cameraRotation;
    public float speed = 12f;
    public float maxSpeed = 50f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Start()
    {
        // centralise & hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // detect movement of mouse 
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // set movement upon key
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // rotate camera upon movement of mouse
        cameraRotation -= mouseY;

        // control rotation of camera
        camera.localRotation = Quaternion.Euler(cameraRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);

        // direction camera is facing
        Vector3 movement = transform.right * moveX + transform.forward * moveZ;

        controller.Move(movement * speed * Time.deltaTime);
        
        // apply gravity to moveable camera 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // make shift increase speed of movement 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxSpeed;
        }
        else
        {
            speed = 12f;
        }
    }
}
