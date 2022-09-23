using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StartTimer : MonoBehaviour
{
    public bool positiveTimer;

    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;

    bool countingDown = false;
    float countDown;

    private BatMovement batMovement;

    private void Start()
    {
        BatMovement.batFinish += Score;
        if (positiveTimer)
        {
            batMovement = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatMovement>();
        }

    }

    private void Score()
    {
        float score = MathF.Round( 10000 / (countDown / 10));
        ScoreManager.Instance.AddScore("TankRacet", score);
    }

    private void Update()
    {
        if (countingDown && positiveTimer)
        {
            countDown += Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
        }
        else if (countingDown && !positiveTimer)
        {
            countDown -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
        }

        if (positiveTimer)
        {

            if (batMovement.finished)
            {
                CountDownEnd();
            }
        }
        else if (countDown <= 0 && !positiveTimer)
        {
            CountDownEnd();
        }
    }

    public void StartCountDown()
    {
        if (positiveTimer)
        {
            batMovement.gameObject.transform.position = batMovement.startPoint.transform.position;
            batMovement.finished = false;
        }
        countDown = timer;
        ScoreManager.Instance.ResetScore();
        objectsToActivate.SetActive(true);
        countingDown = true;
    }

    void CountDownEnd()
    {
        objectsToActivate.SetActive(false);
        countingDown = false;
        timerText.text = "Time: " + 0;
    }
}
