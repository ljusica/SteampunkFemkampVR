using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
        other.gameObject.GetComponent<Ball>().hasLanded = true;
    }
}
