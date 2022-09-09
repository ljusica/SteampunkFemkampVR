using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    TestControlls controller;
    InputAction moveForward;
    InputAction moveBackwad;
    InputAction mouseX;
    InputAction mouseY;
    void Start()
    {
        controller = new TestControlls();
        moveForward = controller.FirstPerson.Forward;
        moveBackwad = controller.FirstPerson.Backward;
        mouseX = controller.FirstPerson.MouseDeltaX;
        mouseY = controller.FirstPerson.MouseDeltaY;

        moveForward.Enable();
        moveBackwad.Enable();
        mouseX.Enable();
        mouseY.Enable();

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
    }

    void MoveForward()
    {
            Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime;
    }
    void MoveBackward()
    {
        Camera.main.transform.position -= Camera.main.transform.forward * Time.deltaTime;
    }
}
