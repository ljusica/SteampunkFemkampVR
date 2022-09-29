using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ImpactArea : MonoBehaviour
{
    [HideInInspector] public bool moving;

    public float duration = 3;
    public float minYPos;
    public float maxYPos;
    public float minXPos;
    public float maxXPos;

    private float endPointY;
    private float endPointX;
    private float offset = 0.5f;

    private Vector3 previousPos;

    public void Move()
    {
        if (moving)
        {
            endPointX = Random.Range(minXPos, maxXPos);
            endPointY = Random.Range(minYPos, maxYPos);

            Vector3 endPoint = new Vector3(endPointX, endPointY, transform.position.z);

            if (endPoint.x < previousPos.x && endPoint.x > previousPos.x - offset)
            {
                endPoint.x = endPoint.x + offset;

                if (endPoint.x > maxXPos)
                {
                    endPoint.x = maxXPos;
                }
            }
            if (endPoint.x > previousPos.x && endPoint.x < previousPos.x + offset)
            {
                endPoint.x = endPoint.x - offset;

                if (endPoint.x < minXPos)
                {
                    endPoint.x = minXPos;
                }
            }
            if (endPoint.y < previousPos.y && endPoint.y > previousPos.y - offset)
            {
                endPoint.y = endPoint.y + offset;

                if (endPoint.y > maxYPos)
                {
                    endPoint.y = maxYPos;
                }
            }
            if (endPoint.y > previousPos.y && endPoint.y < previousPos.y + offset)
            {
                endPoint.y = endPoint.y - offset;

                if (endPoint.y < minYPos)
                {
                    endPoint.y = minYPos;
                }
            }

            var distance = Vector3.Distance(gameObject.transform.position, endPoint);
            transform.DOMove(endPoint, duration * Mathf.Abs(distance)).SetEase(Ease.InCubic).OnComplete(() => Move());

            previousPos = endPoint;
        }
    }
}
