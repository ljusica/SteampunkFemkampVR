using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    Transform endPosNotch;
    void Update()
    {
        RenderNotchString();
    }
    void RenderNotchString()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, endPosNotch.position);
    }


}
