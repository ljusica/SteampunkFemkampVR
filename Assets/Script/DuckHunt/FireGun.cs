using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    TestControlls controller;
    InputAction shoot;
    AudioClip[] clips;
    void Start()
    {
        controller = new TestControlls();
        shoot = controller.FirstPerson.Shoot;
        shoot.Enable();

        shoot.performed += Shoot;
        clips = new AudioClip[3];
        for (int i = 0; i < 2; i++)
        {
            clips[i] = Resources.Load<AudioClip>("Audio/AirRelease" + (i+1));
        }
    }

    public void Shoot(InputAction.CallbackContext call)
    {
        BulletObjectPool.Instance.FireBullet();
        switch (Random.Range(0,2))
        {
            case 0:
                AudioSource.PlayClipAtPoint(clips[0], transform.position);
                break;
            case 1:
                AudioSource.PlayClipAtPoint(clips[1], transform.position);
                break;
            case 2:
                AudioSource.PlayClipAtPoint(clips[2], transform.position);
                break;
        }
    }
}
