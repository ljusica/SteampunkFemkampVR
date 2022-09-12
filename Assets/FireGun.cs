using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    TestControlls controller;
    InputAction shoot;
    void Start()
    {
        controller = new TestControlls();
        shoot = controller.FirstPerson.Shoot;
        shoot.Enable();

        shoot.performed += Shoot;
    }

    public void Shoot(InputAction.CallbackContext call)
    {
        BulletObjectPool.Instance.FireBullet();
    }
}
