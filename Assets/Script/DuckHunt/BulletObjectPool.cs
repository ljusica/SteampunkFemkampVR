using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletObjectPool : MonoBehaviour
{
    public List<Bullet> objectsToPool;
    public GameObject bulletSpawnPoint;
    public GameObject gun;

    ObjectPool<Bullet> bulletPool;

    private static BulletObjectPool instance;
    public static BulletObjectPool Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool);
    }

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(objectsToPool[UnityEngine.Random.Range(0, objectsToPool.Count)]);
        bullet.SetPool(bulletPool);

        return bullet;
    }
    private void OnTakeBulletFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = bulletSpawnPoint.transform.position;

        bullet.Fire(gun.transform.forward);
    }

    private void OnReturnBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void FireBullet()
    {
        bulletPool.Get();
    }

    private void OnDisable()
    {
        Destroy(this);
    }

}
