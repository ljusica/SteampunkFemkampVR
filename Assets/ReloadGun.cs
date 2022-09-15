using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{
    [SerializeField]
    GameObject lever;
    Vector3 startPos;
    Rigidbody rb;
    void Start()
    {
        startPos = lever.transform.localPosition;
        rb = GetComponent<Rigidbody>();
    }

    public void OnReleaseLever()
    {
        Mathf.Lerp(transform.localPosition.z, startPos.z,1);
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
        }
    }
    public void OnGrabLever()
    {
        rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
    }
}
