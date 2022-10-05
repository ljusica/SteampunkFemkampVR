using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objectToFollow.transform);
    }
}
