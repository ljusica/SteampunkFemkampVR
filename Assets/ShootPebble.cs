using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPebble : MonoBehaviour, IShotable
{
    [SerializeField]
    Rigidbody rb;

    Collider collider;
    GameObject notch;
    bool isShootable = true;
    private void Start()
    {
        collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if(transform.parent != null)
        {
            transform.localPosition = Vector3.zero;
        }
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
        StartCoroutine(ReleasePebble());
    }

    public IEnumerator ReleasePebble()
    {
        rb.velocity = notch.transform.forward * 10;
        rb.useGravity = true;
        collider.enabled = true;
    }
}
