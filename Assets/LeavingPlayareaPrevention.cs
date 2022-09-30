using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeavingPlayareaPrevention : MonoBehaviour
{
    [SerializeField]
    Image fogImage;
    [SerializeField]
    float timeUntilFogChange = 3;
    [SerializeField]
    Transform newSpawnPoint;
    GameObject player;

    void PlayerOutsidePlayarea()
    {
         IncreseFog();
    }
    void IncreseFog()
    {
        //Close the fogdistance to player
        fogImage.DOFade(1, timeUntilFogChange).SetEase(Ease.Linear).OnComplete(MovePlayer);
    }
    void DecreaseFog()
    {
        //Further the fogdistance to player again
        fogImage.DOFade(0, timeUntilFogChange).SetEase(Ease.Linear);
    }
    void MovePlayer()
    {
        player.transform.position = newSpawnPoint.position;
        DecreaseFog();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            PlayerOutsidePlayarea();
        }
    }
}
