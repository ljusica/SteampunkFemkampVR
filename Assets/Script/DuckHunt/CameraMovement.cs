using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    TestControlls controller;
    InputAction moveForward;
    InputAction moveBackwad;
    InputAction moveRight;
    InputAction moveLeft;
    private float sensitivity = 10;
    private float moveSpeed = 5;

    void Start()
    {
        controller = new TestControlls();
        moveForward = controller.FirstPerson.Forward;
        moveBackwad = controller.FirstPerson.Backward;
        moveRight = controller.FirstPerson.Right;
        moveLeft = controller.FirstPerson.Left;

        moveForward.Enable();
        moveBackwad.Enable();
        moveRight.Enable();
        moveLeft.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (moveForward.IsPressed())
        {
            MoveForward();
        }else if (moveBackwad.IsPressed())
        {
            MoveBackward();
        }

        if (moveRight.IsPressed())
        {
            MoveRight();
        }else if (moveLeft.IsPressed())
        {
            MoveLeft();
        }

        MoveCamera();
    }

    void MoveForward()
    {
        transform.position += Camera.main.transform.forward * moveSpeed *Time.deltaTime;
    }
    void MoveBackward()
    {
        transform.position -= Camera.main.transform.forward * moveSpeed * Time.deltaTime;
    }
    void MoveRight()
    {
        transform.position += Camera.main.transform.right * moveSpeed * Time.deltaTime;
    }
    void MoveLeft()
    {
        transform.position -= Camera.main.transform.right * moveSpeed * Time.deltaTime;
    }
    void MoveCamera()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        transform.Rotate(Vector3.up * mouse.x * sensitivity * Time.deltaTime);  
        Camera.main.transform.Rotate(Vector3.right * -1 * mouse.y * sensitivity * Time.deltaTime);  
    }
}
