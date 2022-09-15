using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownCollision : MonoBehaviour
{
    private GameObject flipObject;

    private void Start()
    {
        flipObject = transform.parent.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        flipObject.GetComponent<FlipClown>().Flip();
    }
}
