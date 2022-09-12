using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    TestControlls controller;
    InputAction moveForward;
    InputAction moveBackwad;
    private float sensitivity = 10;
    private float moveSpeed = 5;

    void Start()
    {
        controller = new TestControlls();
        moveForward = controller.FirstPerson.Forward;
        moveBackwad = controller.FirstPerson.Backward;

        moveForward.Enable();
        moveBackwad.Enable();

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
    void MoveCamera()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        transform.Rotate(Vector3.up * mouse.x * sensitivity * Time.deltaTime);  
        Camera.main.transform.Rotate(Vector3.right * -1 * mouse.y * sensitivity * Time.deltaTime);  
    }
}
