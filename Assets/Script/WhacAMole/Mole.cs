using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Mole : MonoBehaviour
{
    public Vector3 hidingPos;
    public Vector3 openPos;
    private bool hidden = true;

    public delegate void Whack(Mole mole);
    public static Whack whack;

    void Awake()
    {
        hidingPos = transform.position;
        openPos = new Vector3(hidingPos.x, hidingPos.y + 0.12f, hidingPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball" && !hidden)
        {
            Hide();
            whack?.Invoke(this);
        }
    }

    public void Hide()
    {
        transform.DOMove(hidingPos, 0.2f);
        hidden = true;
    }

    public void Open()
    {
        transform.DOMove(openPos, 0.2f);
        hidden = false;
    }
}
