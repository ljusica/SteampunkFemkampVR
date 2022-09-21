using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Mole : MonoBehaviour
{
    public Vector3 hidingPos;
    public Vector3 openPos;
    public bool hidden;

    public delegate void Whack(Mole mole);
    public static Whack whack;

    void Start()
    {
        hidingPos = transform.position;
        openPos = new Vector3(hidingPos.x, hidingPos.y + 0.12f, hidingPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Hide();
            whack?.Invoke(this);
        }
    }

    public void Hide()
    {
        transform.DOMove(hidingPos, 0.4f);
        hidden = true;
    }

    public void Open()
    {
        transform.DOMove(openPos, 0.4f);
        hidden = false;
    }
}
