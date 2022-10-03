using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;

    bool hasGameStarted = false;
    public bool countingDown = false;
    float countDown;

    private void Update()
    {
        if (countingDown)
        {
            hasGameStarted = true;
            countDown -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
        }

        if (countDown <= 0 && hasGameStarted)
        {
            CountDownEnd();
        }
    }

    public void StartCountDown()
    {
        //This line stops the scenetransition of a pentathlon run if the player wants to retry a game
        StopCoroutine(GameManager.Instance.GoToNextGameInPenthathlon());
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

        //This transitions the player to the next game if they are doing a pentathlon run
        if (GameManager.Instance.isDoingPenthathlonRun)
        {
            StartCoroutine(GameManager.Instance.GoToNextGameInPenthathlon());
        }
    }
}
