using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractionManager : XRInteractionManager
{
    public void ForceDeselect(IXRSelectInteractor interactor)
    {
        if (interactor.hasSelection)
            SelectExit(interactor, interactor.firstInteractableSelected);
    }
}