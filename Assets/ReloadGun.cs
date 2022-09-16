using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadGun : MonoBehaviour
{
    [SerializeField]
    XRGrabInteractable interactable;


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
            interactable.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
            interactable.enabled = true;
        }
    }
    public void OnGrabLever()
    {
        
    }
}
