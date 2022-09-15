using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objectToFollow.transform);
    }
}
