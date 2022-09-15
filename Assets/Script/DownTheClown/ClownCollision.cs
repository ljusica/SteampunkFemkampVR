using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownCollision : MonoBehaviour
{
    private GameObject flipObject;
    private Clown clown;

    private void Start()
    {
        flipObject = transform.parent.gameObject;
        clown = GetComponent<Clown>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        flipObject.GetComponent<FlipClown>().Flip();
        if(!clown.flipped)
            ClownKnockEvent.TriggerKnock(flipObject);
        clown.flipped = true;
    }
}
