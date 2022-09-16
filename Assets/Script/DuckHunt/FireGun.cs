using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    TestControlls controller;
    InputAction shoot;
    AudioClip[] clips;
    AudioSource source;
    public static bool canShoot = true;
    void Start()
    {
        //controller = new TestControlls();
        //shoot = controller.FirstPerson.Shoot;
        //source = GetComponent<AudioSource>();
        //shoot.Enable();

        //shoot.performed += Shoot;
        clips = new AudioClip[3];
        for (int i = 0; i < 2; i++)
        {
            clips[i] = Resources.Load<AudioClip>("Audio/AirRelease" + (i+1));
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            BulletObjectPool.Instance.FireBullet();
            switch (Random.Range(0,2))
            {
                case 0:
                    source.clip = clips[0];
                    source.Play();
                    break;
                case 1:
                    source.clip = clips[1];
                    source.Play();
                    break;
                case 2:
                    source.clip = clips[2];
                    source.Play();
                    break;
            }
            canShoot = false;
        }
    }
}
