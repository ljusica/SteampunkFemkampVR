using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class Mole : MonoBehaviour
{
    public Vector3 hidingPos;
    public Vector3 openPos;
    public ParticleSystem particleSystem;

    private bool hidden = true;
    private float speed = 0.2f;
    private float offset = 0.12f;
    private float hapticForce = 0.4f;
    private float hapticDuration = 0.1f;
    private float teddyYScale;

    [SerializeField]
    AudioSource audioSource;

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
        teddyYScale = transform.localScale.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball" && !hidden)
        {
            Hide();
            whack?.Invoke(this);
            CompressTeddyOnHit();
            particleSystem.Emit(5);
            HammerHand.hammerHand.SendHapticImpulse(hapticForce, hapticDuration);
            audioSource.pitch = UnityEngine.Random.Range(0.6f,1.2f);
            audioSource.Play();
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

        if (moles.Contains(this)) return;

        //foreach(Mole mole in moles)
        //{
        //    if (mole == this)
        //        return;
        //}
        moles.Add(this);
    }

    void CompressTeddyOnHit()
    {
        transform.DOScaleY(teddyYScale - 2, 0.25f).SetEase(Ease.OutBounce).OnComplete(ResetTeddyComression);
    }
    void ResetTeddyComression()
    {
        transform.DOScaleY(teddyYScale, 0.5f);
    }
    private void OnDisable()
    {
        MoleManager.gameOver -= GameOver;
    }
}
