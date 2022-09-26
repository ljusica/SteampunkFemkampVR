using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollider : MonoBehaviour
{
    public float score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Ball") return;
        ScoreManager.Instance.AddScore("SkeeBall", score);
        other.gameObject.GetComponent<Ball>().hasScored = true;
    }
}
