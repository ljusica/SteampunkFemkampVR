using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPebble : MonoBehaviour, IShotable
{
    public Transform resetPoint;

    [SerializeField]
    Rigidbody rb;

    Collider collider;
    GameObject notch;
    bool isShootable = true;
    float gravity = 9.81f;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if (transform.parent != null)
        {
            transform.localPosition = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity * Time.deltaTime, rb.velocity.z);
    }
    public bool IsShotable()
    {
        return isShootable;
    }

    public void OnAttach(GameObject obj)
    {
        if (isShootable)
        {
            notch = obj;
            collider.enabled = false;
            rb.useGravity = false;
            transform.parent = obj.transform;
            transform.localPosition = Vector3.zero;

        }
    }

    public void OnRelease()
    {
        isShootable = false;
        transform.parent = null;
        gravity = gravity / 2;
        StartCoroutine(ReleasePebble());
    }

    public IEnumerator ReleasePebble()
    {
        rb.velocity = notch.transform.forward * 10;
        collider.enabled = true;
        Invoke(nameof(ResetPebble), 3);
        yield return null;
    }


    private void ResetPebble()
    {
        transform.position = resetPoint.position;
        rb.velocity = Vector3.zero;
        gravity = 9.81f;
    }
}
