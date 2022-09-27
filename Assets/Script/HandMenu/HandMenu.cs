using UnityEngine;
using UnityEngine.InputSystem;

public class HandMenu : MonoBehaviour
{
    private XRHandMenu XRHandMenu;
    private InputAction openMenuInput;
    private bool isMenuOpen;

    public GameObject menuObj;

    private void Awake()
    {
        XRHandMenu = new XRHandMenu();
        openMenuInput = XRHandMenu.UI.HandMenu;

        openMenuInput.started += OpenMenu;
        openMenuInput.canceled += OpenMenu;
    }

    private void Update()
    {
        menuObj.SetActive(isMenuOpen);
    }

    private void OnEnable()
    {
        openMenuInput.Enable();
    }
    private void OnDisable()
    {
        openMenuInput.Disable();
    }

    private void OpenMenu(InputAction.CallbackContext obj)
    {
        isMenuOpen = isMenuOpen ? false : true;
    }
}
