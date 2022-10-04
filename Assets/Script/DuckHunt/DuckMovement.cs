using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckMovement : MonoBehaviour
{
    public GameObject[] ducksTier1;
    public GameObject[] ducksTier2;
    public GameObject[] ducksTier3;

    public float farLeft;
    public float farRight;
    public float hidingPos;
    public float speedTier1;
    public float speedTier2;
    public float speedTier3;

    private float startPosY;
    private float startYTier1;
    private float startYTier2;
    private float startYTier3;
    
    private float endPoint;
    private float timer;
    private float counter = 5;

    private int hidingPropability;

    void Start()
    {
        timer = Time.time;

        startYTier1 = CalculateStartingPosition(ducksTier1, speedTier1);
        startYTier2 = CalculateStartingPosition(ducksTier2, speedTier2);
        startYTier3 = CalculateStartingPosition(ducksTier3, speedTier3);
    }

    private void Update()
    {
        if (Time.time >= timer + counter)
        {
            CalculateHide(ducksTier1, 2, startYTier1);
            CalculateHide(ducksTier2, 3, startYTier2);
            CalculateHide(ducksTier3, 4, startYTier3);

            counter = Random.Range(2, 7);
            timer = Time.time;
        }

    }

    private float CalculateStartingPosition(GameObject[] ducks, float speed)
    {
        for (int i = 0; i < ducks.Length; i++)
        {
            startPosY = ducks[i].transform.localPosition.y;
            hidingPos = startPosY - 2f;

            Move(ducks[i], speed);
        }

        return startPosY;
    }

    private float ChooseNewDestination()
    {
        endPoint = Random.Range(farLeft, farRight);
        return endPoint;
    }

    private void Move(GameObject duck, float speed)
    {
        float duckDestination = ChooseNewDestination();

        duck.transform.DOLocalMoveX(duckDestination, speed / Mathf.Abs(duck.transform.position.x - duckDestination)).OnComplete(() => Move(duck, speed));
    }

    private void CalculateHide(GameObject[] ducks, int maxChance, float startPositionY)
    {
        for (int i = 0; i < ducks.Length; i++)
        {
            hidingPropability = Random.Range(0, maxChance);

            if (hidingPropability > 0)
            {
                Hide(ducks[i]);
            }
            else
            {
                ducks[i].transform.DOLocalMoveY(startPositionY, 1);
            }
        }
    }

    public void Hide(GameObject duck)
    {
        duck.transform.DOLocalMoveY(hidingPos, 1);
    }

}