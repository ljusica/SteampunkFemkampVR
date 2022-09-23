using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public bool finished = false;
    public delegate void BatFinish();
    public static BatFinish batFinish;

    private float score;
    private bool moving;

    private void Start()
    {
        gameObject.transform.position = startPoint.transform.position;
    }

    void Update()
    {
        //score = ScoreManager.Instance.GetScore("TankRacet");

        //gameObject.transform.DOMoveX(endPoint.transform.position.x, score * Time.deltaTime);

        //if(gameObject.transform.position.x >= endPoint.transform.position.x)
        //{
        //    finished = true;
        //}
    }

    public void Move()
    {
        if (!moving)
        {
            moving = true;

            gameObject.transform.DOMoveX(transform.position.x + 0.05f, 0.1f).OnComplete(() => moving = false);

            if (gameObject.transform.position.x >= endPoint.transform.position.x)
            {
                finished = true;
                batFinish?.Invoke();
            }
        }

    }

}
