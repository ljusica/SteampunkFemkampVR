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

    void Start()
    {
        Move(minXPos, maxXPos, minYPos, maxYPos);
    }

    void Move(float minX, float maxX, float minY, float maxY)
    {
        endPointX = Random.Range(minX, maxX);
        endPointY = Random.Range(minY, maxY);

        Vector3 endPoint = new Vector3(endPointX, endPointY, transform.position.z);

        transform.DOMove(endPoint, duration).SetEase(Ease.OutBounce).OnComplete(() => Move(minXPos, maxXPos, minYPos, maxYPos));
    }
}
