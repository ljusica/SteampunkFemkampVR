using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(PullMeasurer))]
public class Notch : XRSocketInteractor
{
    [SerializeField, Range(0, 1)] private float releaseThreshold = 0.25f;

    public PullMeasurer PullMeasurer { get; private set; } = null;
    public bool IsReady { get; private set; } = false;

    // Need to cast to custom for Force Deselect
    private CustomInteractionManager CustomManager => interactionManager as CustomInteractionManager;

    protected override void Awake()
    {
        base.Awake();
        PullMeasurer = GetComponentInChildren<PullMeasurer>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        // Arrow is released once the puller is released
        PullMeasurer.selectExited.AddListener(ReleaseArrow);
        // Move the point where the arrow is attached
        PullMeasurer.Pulled.AddListener(MoveAttach);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        PullMeasurer.selectExited.RemoveListener(ReleaseArrow);
        PullMeasurer.Pulled.RemoveListener(MoveAttach);
    }

    public void ReleaseArrow(SelectExitEventArgs args)
    {
        if (selectTarget is Pebble && PullMeasurer.PullAmount > releaseThreshold)
            CustomManager.ForceDeselect(this);
    }

    public void MoveAttach(Vector3 pullPosition, float pullAmount)
    {
        // Move attach when bow is pulled, this updates the renderer as well
        attachTransform.position = pullPosition;
    }

    public void SetReady(BaseInteractionEventArgs args)
    {
        // Set the notch ready if bow is selected
        IsReady = args.interactable.isSelected;
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        // We check for the hover here too, since it factors in the recycle time of the socket
        // We also check that notch is ready, which is set once the bow is picked up
        return base.CanSelect(interactable) && CanHover(interactable) && IsPebble(interactable);
    }

    private bool IsPebble(XRBaseInteractable interactable)
    {
        // Simple arrow check, can be tag or interaction layer as well
        return interactable is Pebble;
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        // Use instantaneous so it follows smoothly
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }

    // This enables the socket to grab the arrow immediately
    public override bool requireSelectExclusive => false;
}