using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class StartTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;
    public bool countingDown = false;
    public float buttonAnimOffset = 0.25f;
    public AudioSource audioSource;

    bool hasGameStarted = false;
    bool buttonIsDown = false;
    float countDown;
    float buttonAnimateCountdown = 0;
    Vector3 buttonPos;
    private void Start()
    {
        buttonPos = transform.position;
    }

    private void Update()
    {
        if (countingDown)
        {
            hasGameStarted = true;
            countDown -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(countDown);
            AnimateButton();
        }

        if (countDown <= 0 && hasGameStarted)
        {
            CountDownEnd();
        }
    }

    public void StartCountDown()
    {
        //This line stops the scenetransition of a pentathlon run if the player wants to retry a game
        if (GameManager.Instance.isDoingPenthathlonRun)
        {
            StopCoroutine(GameManager.Instance.GoToNextGameInPenthathlon());
        }
        countDown = timer;
        ScoreManager.Instance.ResetScore();
        objectsToActivate.SetActive(true);
        countingDown = true;
        audioSource.Play();
    }

    void CountDownEnd()
    {
        if (buttonAnimateCountdown > 1.2) return;

        objectsToActivate.SetActive(false);
        countingDown = false;
        timerText.text = "Time: " + 0;

        //This transitions the player to the next game if they are doing a pentathlon run
        if (GameManager.Instance.isDoingPenthathlonRun)
        {
            StartCoroutine(GameManager.Instance.GoToNextGameInPenthathlon());
        }
    }
    void AnimateButton()
    {
        if (!buttonIsDown)
        {
            
            buttonAnimateCountdown += Time.deltaTime;

            if(buttonAnimateCountdown > 1)
            {
                buttonIsDown = true;
            }
        }

        if (buttonIsDown) { buttonAnimateCountdown -= Time.deltaTime; }

        transform.position = new Vector3(buttonPos.x, Mathf.Lerp(transform.position.y, buttonPos.y - buttonAnimOffset, buttonAnimateCountdown), buttonPos.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Club") || collision.gameObject.CompareTag("Gun") || collision.gameObject.CompareTag("Slingshot"))
        {
            StartCountDown();
        }
    }
}
