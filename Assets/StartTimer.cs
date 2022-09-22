using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            batMovement = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatMovement>();

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
