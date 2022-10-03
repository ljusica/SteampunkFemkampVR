using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachShootable : MonoBehaviour
{
    public GameObject notch;
    IShotable shotable;
    bool hasAttached = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IShotable>() != null)
        {
            if (!hasAttached && other.GetComponent<IShotable>().IsShotable()) {
                other.GetComponent<XRGrabInteractable>().enabled = false;
                shotable = other.GetComponent<IShotable>();
                shotable.OnAttach(notch);
                hasAttached = true;
            } 

        }
    }
    public void OnRelease()
    {
        if(shotable != null)
        {
            shotable.OnRelease();
            shotable = null;
            hasAttached = false;
        }
    }
}
