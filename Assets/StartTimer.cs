using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject ducks;

    bool countingDown = false;
    float countDown;
    private void Update()
    {
        if (countingDown)
        {
            countDown -= Time.deltaTime;
            timerText.text = "Time: " + countDown;
        }

        if(countDown < 0)
        {
            CountDownEnd();
        }
    }
    public void StartCountDown()
    {
        countDown = timer;
        scoreText.text = "Score: ";
        ducks.SetActive(true);
        countingDown = true;
    }
    void CountDownEnd()
    {
        ducks.SetActive(false);
        countingDown = false;
        timerText.text = "Time: " +0;
    }
}
