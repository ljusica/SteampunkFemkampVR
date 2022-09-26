using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;

    bool countingDown = false;
    float countDown;

    private void Update()
    {
        if (countingDown)
        {
            countDown -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
        }

        if (countDown <= 0)
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
