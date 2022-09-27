using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadGun : MonoBehaviour
{
    public bool isBackTrigger = true;
    static bool hasHitBackTrigger = false;

    [SerializeField]
    AudioSource audio;
    [SerializeField]
    FireGun fireGunScript;
    [SerializeField]
    XRGrabInteractable interactable;



    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("ReloadLever") && isBackTrigger)
        {
            interactable.enabled = false;
            hasHitBackTrigger = true;
            audio.Play();
        }
        if (collision.CompareTag("ReloadLever") && hasHitBackTrigger && !isBackTrigger)
        {
            fireGunScript.Reload();
            interactable.enabled = true;
        }
    }
}
