using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DuckMovement : MonoBehaviour
{
    public GameObject[] ducks;

    public float farLeft;
    public float farRight;

    private float endPoint;

    void Start()
    {
        for (int i = 0; i < ducks.Length; i++)
        {
            Move(ducks[i]);
        }
    }

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

}
