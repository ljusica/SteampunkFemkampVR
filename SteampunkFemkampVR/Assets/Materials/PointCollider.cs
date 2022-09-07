using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollider : MonoBehaviour
{
    //public GameObject scoreKeeperTemp;
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            //scoreKeeperTemp.GetComponent<ScoreKeeper>().score += score;
        }
    }
}
