using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckMovement : MonoBehaviour
{
    public GameObject[] ducks;

    public float farLeft;
    public float farRight;
    public float hidingPos;

    private float startPosY;
    private float endPoint;
    private float timer;
    private float counter = 5;

    private int hidingPropability;

    void Start()
    {
        timer = Time.time;

        for (int i = 0; i < ducks.Length; i++)
        {
            startPosY = ducks[i].transform.position.y;
            hidingPos = startPosY - 1;

            Move(ducks[i]);
        }

    }

    //private void Update()
    //{
    //    if (Time.time >= timer + counter)
    //    {
    //        for (int i = 0; i < ducks.Length; i++)
    //        {
    //            hidingPropability = Random.Range(0, 2);

    //            if (hidingPropability > 0)
    //            {
    //                Hide(ducks[i]);
    //            }
    //        }

    //        counter = Random.Range(2, 7);
    //        timer = Time.time;
    //    }

    //}

    private float ChooseNewDestination()
    {
        endPoint = Random.Range(farLeft, farRight);
        return endPoint;
    }

    private void Move(GameObject duck)
    {
        float duckDestination = ChooseNewDestination();

        duck.transform.DOMoveX(duckDestination, 10 * Mathf.Abs(duck.transform.position.x - duckDestination)).OnComplete(() => Move(duck));
    }

    public void Hide(GameObject duck)
    {
        duck.transform.DOMoveY(hidingPos, counter);
    }

}
