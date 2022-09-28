using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachShootable : MonoBehaviour
{
    public GameObject notch;
    IShotable shotable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IShotable>() != null)
        {
            other.GetComponent<XRGrabInteractable>().enabled = false;
            shotable = other.GetComponent<IShotable>();
            shotable.OnAttach(notch);
        }
    }
    public void OnRelease()
    {
        if(shotable != null)
        {
            shotable.OnRelease();
            shotable = null;
        }
    }
}
