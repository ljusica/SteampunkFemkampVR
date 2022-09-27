using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    public static int maxBullets = 3;
    static int bulletLeft;
    AudioClip[] clips;
    AudioSource source;
    void Start()
    {
        bulletLeft = maxBullets;
        source = GetComponent<AudioSource>();
        clips = new AudioClip[3];
        for (int i = 0; i < 2; i++)
        {
            clips[i] = Resources.Load<AudioClip>("Audio/AirRelease" + (i+1));
        }
    }
    public static void Reload()
    {
        bulletLeft = maxBullets;
    }
    public void Shoot()
    {
        if (bulletLeft > 0)
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
            bulletLeft--;
        }
    }
}
