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

    bool alreadyGotScore = false;
    private GameObject duck;
    private DuckMovement duckMovement;
    private DuckPoints duckPoints;
    AudioSource sourceSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sourceSFX = GetComponent<AudioSource>();
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
        alreadyGotScore = false;
    }
    public void ReturnTooPool()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        timer = 0;
        pool.Release(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Duck"))
        {
            if (!alreadyGotScore)
            {
                duck = other.gameObject;
                duckMovement = duck.GetComponentInParent<DuckMovement>();
                duckPoints = duck.GetComponentInParent<DuckPoints>();
                ScoreManager.Instance.AddScore("DuckHunt", duckPoints.points);
                duckMovement.Hide(duck);
                rb.velocity = Vector3.zero;
                alreadyGotScore = true;
                Debug.Log(duckPoints.points);
            }
        }
        else
        {
            sourceSFX.pitch = Random.Range(0.8f,1.4f);
            sourceSFX.Play();
        }

        rb.useGravity = true;
    }
}
