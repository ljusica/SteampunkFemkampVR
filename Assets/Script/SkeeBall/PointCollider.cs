using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollider : MonoBehaviour
{
    public float score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            ScoreManager.Instance.AddScore("SkeeBall", score);
        }
    }
}
