using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPos : MonoBehaviour
{
    public Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
}
