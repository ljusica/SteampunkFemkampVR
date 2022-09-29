using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatMovement : MonoBehaviour
{
    public float speed;

    public Transform startPoint;
    public Transform endPoint;

    [HideInInspector] public bool finished = false;
    public delegate void BatFinish();
    public static BatFinish batFinish;

    private bool moving;

    private void Start()
    {
        gameObject.transform.position = startPoint.transform.position;
    }

    public void Move()
    {
        if (!moving)
        {
            moving = true;

            gameObject.transform.DOMoveX(transform.position.x + 0.05f, speed).OnComplete(() => moving = false);

            if (gameObject.transform.position.x >= endPoint.transform.position.x)
            {
                finished = true;
                batFinish?.Invoke();
            }
        }

    }

}
