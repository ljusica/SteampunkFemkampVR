using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{
    [SerializeField]
    GameObject lever;
    Vector3 startPos;
    void Start()
    {
        startPos = lever.transform.localPosition;
    }

    public void OnReleaseLever()
    {
        Mathf.Lerp(transform.localPosition.z, startPos.z,1);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
        }
    }
}
