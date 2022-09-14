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

    private GameObject duck;
    private DuckMovement duckMovement;

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
        rb = GetComponent<Rigidbody>();
        rb.velocity = forward * firePower;
    }
    public void ReturnTooPool()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        timer = 0;
        pool.Release(this);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Duck"))
        {
            duck = other.gameObject;
            duckMovement = duck.GetComponentInParent<DuckMovement>();

            duckMovement.Hide(duck);
        }

        rb.useGravity = true;
    }
}
