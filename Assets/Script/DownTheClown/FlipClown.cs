using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipClown : MonoBehaviour
{
    Vector3 flipRot;
    Vector3 origRot;

    private void Start()
    {
        origRot = transform.rotation.eulerAngles;
        flipRot = new Vector3(origRot.x + 90, origRot.y, origRot.z);
    }

    public void Flip()
    {
        transform.DORotate(flipRot, 0.3f);
    }

    public void BackFlip()
    {
        transform.DORotate(origRot, 0.3f);
    }
}
