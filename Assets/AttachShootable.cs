using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachShootable : MonoBehaviour
{
    public GameObject notch;
    IShotable shotable;
    public SelectExitEvent selectExited { get; set; }
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
        shotable.OnRelease();
    }
}
