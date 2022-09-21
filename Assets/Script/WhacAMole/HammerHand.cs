using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HammerHand : MonoBehaviour
{
    public static XRController hammerHand;
    private XRGrabInteractable interactor;

    private void Awake()
    {
        interactor = GetComponent<XRGrabInteractable>();
        interactor.selectEntered.AddListener(SetHand);
    }

    private void SetHand(SelectEnterEventArgs args)
    {
        hammerHand = args.interactorObject.transform.GetComponent<XRController>();
    }

    private void OnDisable()
    {
        hammerHand = null;
    }
}
