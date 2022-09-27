using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPebble : MonoBehaviour, IShotable
{
    [SerializeField]
    Rigidbody rb;

    Vector3 direction;
    Vector3 pos1;
    bool isShootable = true;

    public bool IsShotable()
    {
        return isShootable;
    }

    public void OnAttach(GameObject obj)
    {
        if (isShootable)
        {
            transform.position = Vector3.zero;
            transform.parent = obj.transform;
            rb.useGravity = false;
        }
    }

    public void OnRelease()
    {
        isShootable = false;
        StartCoroutine(ReleasePebble());
    }

    public IEnumerator ReleasePebble()
    {
        pos1 = transform.position;
        yield return new WaitForSeconds(0.1f);
        direction = transform.position - pos1;
        rb.velocity = direction;
        rb.useGravity = true;
    }
}
