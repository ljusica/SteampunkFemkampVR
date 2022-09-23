using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ImpactArea : MonoBehaviour
{
    public float duration = 3;

    public float minYPos;
    public float maxYPos;
    public float minXPos;
    public float maxXPos;

    private float endPointY;
    private float endPointX;
    private float offset = 0.5f;

    private Vector3 previousPos;

    void Start()
    {
        Move(minXPos, maxXPos, minYPos, maxYPos);
    }

    void Move(float minX, float maxX, float minY, float maxY)
    {
        endPointX = Random.Range(minX, maxX);
        endPointY = Random.Range(minY, maxY);

        Vector3 endPoint = new Vector3(endPointX, endPointY, transform.position.z);

        if (endPoint.x < previousPos.x && endPoint.x > previousPos.x - offset)
        {
            endPoint.x = endPoint.x + offset;

            if(endPoint.x > maxXPos)
            {
                endPoint.x = maxXPos;
            }
        }
        if (endPoint.x > previousPos.x && endPoint.x < previousPos.x + offset)
        {
            endPoint.x = endPoint.x - offset;

            if(endPoint.x < minXPos)
            {
                endPoint.x = minXPos;
            }
        }
        if (endPoint.y < previousPos.y && endPoint.y > previousPos.y - offset)
        {
            endPoint.y = endPoint.y + offset;

            if(endPoint.y > maxYPos)
            {
                endPoint.y = maxYPos;
            }
        }
        if (endPoint.y > previousPos.y && endPoint.y < previousPos.y + offset)
        {
            endPoint.y = endPoint.y - offset;
           
            if(endPoint.y < minYPos)
            {
                endPoint.y = minYPos;
            }
        }

        transform.DOMove(endPoint, duration).SetEase(Ease.InOutBounce).OnComplete(() => Move(minXPos, maxXPos, minYPos, maxYPos));

        previousPos = endPoint;
    }
}
