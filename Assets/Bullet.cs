using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    IObjectPool<Bullet> pool;
    Rigidbody rb;
    float firePower = 10;
    float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 4)
        {
            ReturnTooPool();
        }
    }
    public void SetPool(IObjectPool<Bullet> pool) =>    this.pool = pool;

    public void Fire(Vector3 forward)
    {
        GetComponent<Rigidbody>().velocity = forward * firePower;
    }
    public void ReturnTooPool()
    {
        rb.velocity = Vector3.zero;
        timer = 0;
        pool.Release(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Anka"))
        {
            ReturnTooPool();
        }
    }
}
