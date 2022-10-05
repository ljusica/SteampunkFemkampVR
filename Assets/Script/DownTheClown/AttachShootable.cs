using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachShootable : MonoBehaviour
{
    public GameObject notch;

    [SerializeField]
    AudioSource audioSource;

    AudioClip slingShotPullClip;
    AudioClip slingShotReleaseClip;
    AudioClip slingShotPelletAddClip;
    IShotable shotable;
    bool hasAttached = false;

    private void Start()
    {
        slingShotPullClip = Resources.Load<AudioClip>("Audio/SlingShotPullClip");
        slingShotReleaseClip = Resources.Load<AudioClip>("Audio/SlingShotReleaseClip");
        slingShotPelletAddClip = Resources.Load<AudioClip>("Audio/SlingShotPelletAddClip");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IShotable>() != null)
        {
            if (!hasAttached && other.GetComponent<IShotable>().IsShotable()) {
                other.GetComponent<XRGrabInteractable>().enabled = false;
                shotable = other.GetComponent<IShotable>();
                shotable.OnAttach(notch);
                hasAttached = true;

                audioSource.clip = slingShotPelletAddClip;
                audioSource.Play();
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
            audioSource.clip = slingShotReleaseClip;
            audioSource.Play();
        }
    }
    public void OnGrab()
    {
        audioSource.clip = slingShotPullClip;
        audioSource.Play();
    }
}
