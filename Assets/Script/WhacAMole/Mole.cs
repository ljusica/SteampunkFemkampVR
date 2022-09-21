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
    private float speed = 0.2f;
    private float offset = 0.12f;
    private float hapticForce = 0.4f;
    private float hapticDuration = 0.1f;

    public delegate void Whack(Mole mole);
    public static Whack whack;

    void Awake()
    {
        hidingPos = transform.position;
        openPos = new Vector3(hidingPos.x, hidingPos.y + offset, hidingPos.z);
    }

    private void Start()
    {
        MoleManager.gameOver += GameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball" && !hidden)
        {
            Hide();
            whack?.Invoke(this);
            HammerHand.hammerHand.SendHapticImpulse(hapticForce, hapticDuration);
        }
    }

    public void Hide()
    {
        transform.DOMove(hidingPos, speed);
        hidden = true;
    }

    public void Open()
    {
        transform.DOMove(openPos, speed);
        hidden = false;
    }

    public void GameOver(List<Mole> moles)
    {
        transform.DOMove(hidingPos, speed);
        hidden = true;
        foreach(Mole mole in moles)
        {
            if (mole == this)
                return;
        }
        moles.Add(this);
    }
}
