using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPebble : MonoBehaviour, IShotable
{
    [SerializeField]
    Rigidbody rb;

    Vector3 direction;
    Vector3 pos1;
    GameObject notch;
    bool isShootable = true;

    public bool IsShotable()
    {
        return isShootable;
    }

    public void OnAttach(GameObject obj)
    {
        if (isShootable)
        {
            notch = obj;
            rb.useGravity = false;
            transform.parent = obj.transform;
            transform.localPosition = obj.transform.forward;
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
        yield return new WaitForSeconds(0.1f);
        rb.velocity = notch.transform.forward * 10;
        rb.useGravity = true;
    }
}
