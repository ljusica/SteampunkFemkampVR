using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class HandAnimation : MonoBehaviour
{
    private XRHandMenu XrHandMenu;

    private Animator animator;
    public string whichHand;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        XrHandMenu = new XRHandMenu();
        XrHandMenu.Enable();

        if(whichHand == "Right")
        {
            XrHandMenu.HandAnimations.GripRight.performed += Gripping;
            XrHandMenu.HandAnimations.GripRight.canceled += GripRelease;

            XrHandMenu.HandAnimations.PinchRight.performed += Pinching;
            XrHandMenu.HandAnimations.PinchRight.canceled += PinchRelease;
        }
        else if (whichHand == "Left")
        {
            XrHandMenu.HandAnimations.GripLeft.performed += Gripping;
            XrHandMenu.HandAnimations.GripLeft.canceled += GripRelease;

            XrHandMenu.HandAnimations.PinchLeft.performed += Pinching;
            XrHandMenu.HandAnimations.PinchLeft.canceled += PinchRelease;
        }
    }

    private void Gripping(InputAction.CallbackContext obj) => animator.SetFloat("Grip", obj.ReadValue<float>());

    private void GripRelease(InputAction.CallbackContext obj) => animator.SetFloat("Grip", 0f);

    private void Pinching(InputAction.CallbackContext obj) => animator.SetFloat("Pinch", obj.ReadValue<float>());

    private void PinchRelease(InputAction.CallbackContext obj) => animator.SetFloat("Pinch", 0f);


    private void OnDisable()
    {
        if (whichHand == "Right")
        {
            XrHandMenu.HandAnimations.GripRight.performed -= Gripping;
            XrHandMenu.HandAnimations.GripRight.canceled -= GripRelease;

            XrHandMenu.HandAnimations.PinchRight.performed -= Pinching;
            XrHandMenu.HandAnimations.PinchRight.canceled -= PinchRelease;
        }
        else if (whichHand == "Left")
        {
            XrHandMenu.HandAnimations.GripLeft.performed -= Gripping;
            XrHandMenu.HandAnimations.GripLeft.canceled -= GripRelease;

            XrHandMenu.HandAnimations.PinchLeft.performed -= Pinching;
            XrHandMenu.HandAnimations.PinchLeft.canceled -= PinchRelease;
        }
    }
}
