using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnReleaseLever()
    {
        rb.isKinematic = true;
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
            Debug.Log("Reload");
        }
    }
    public void OnGrabLever()
    {
        rb.isKinematic = false;
    }
}
