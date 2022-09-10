using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.transform.position = other.GetComponent<BallPos>().startPos;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
