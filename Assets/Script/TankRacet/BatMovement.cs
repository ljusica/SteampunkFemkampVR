using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    [HideInInspector] public bool finished = false;

    private float score;

    private void Start()
    {
        gameObject.transform.position = startPoint.transform.position;
    }

    void Update()
    {
        score = ScoreManager.Instance.GetScore("TankRacet");

        gameObject.transform.DOMoveX(endPoint.transform.position.x, score * Time.deltaTime);

        if(gameObject.transform.position.x >= endPoint.transform.position.x)
        {
            finished = true;
        }
    }

}
