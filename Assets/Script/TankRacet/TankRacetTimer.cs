using System;
using TMPro;
using UnityEngine;

public class TankRacetTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;

    private float countDown;
    private BatMovement batMovement;
    private bool countingDown;

    private void Start()
    {
        BatMovement.batFinish += Score;
        batMovement = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatMovement>();
    }

    private void Score()
    {
        float score = MathF.Round(10000 / (countDown / 10));
        ScoreManager.Instance.AddScore("TankRacet", score);
    }

    private void Update()
    {
        if (countingDown)
        {
            countDown += Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
        }

        if (batMovement.finished) CountDownEnd();
    }

    public void StartCountDown()
    {
        batMovement.gameObject.transform.position = batMovement.startPoint.transform.position;
        batMovement.finished = false;
        countDown = timer;
        ScoreManager.Instance.ResetScore();
        objectsToActivate.SetActive(true);
    }

    void CountDownEnd()
    {
        objectsToActivate.SetActive(false);
        timerText.text = "Time: " + 0;
    }
}
