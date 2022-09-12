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
        switch (Random.Range(0,2))
        {
            case 0:
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/AirRelease1"), transform.position);
                break;
            case 1:
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/AirRelease2"), transform.position);
                break;
            case 2:
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audio/AirRelease3"), transform.position);
                break;
        }
    }
}
