using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public delegate void OnFlip();
public class FlipClown : MonoBehaviour
{
    public event OnFlip onFlip;

    Vector3 flipRot;
    Vector3 origRot;

    private Clown clown;

    private void Start()
    {
        clown = transform.GetComponentInChildren<Clown>();
        origRot = transform.rotation.eulerAngles;
        flipRot = new Vector3(origRot.x + 90, origRot.y, origRot.z);
    }

    public void Flip()
    {
        transform.DORotate(flipRot, 0.3f);
        onFlip?.Invoke();
    }

    public void BackFlip()
    {
        transform.DORotate(origRot, 0.3f);
    }
}
