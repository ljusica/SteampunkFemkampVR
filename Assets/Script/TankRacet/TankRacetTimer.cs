using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TankRacetTimer : MonoBehaviour
{
    public float timer;
    public TextMeshPro scoreText;
    public TextMeshPro timerText;
    public GameObject objectsToActivate;
    public GameObject jaw;
    public ImpactArea vampire;

    private Vector3 jawDown;
    private Vector3 jawUp;
    private float countDown;
    private BatMovement batMovement;
    private bool countingDown;

    private void Start()
    {
        BatMovement.batFinish += Score;
        batMovement = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatMovement>();
        jawUp = jaw.transform.localPosition;
        jawDown = new Vector3(jawUp.x, jawUp.y - 0.6f, jawUp.z);
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
        vampire.moving = true;
        batMovement.gameObject.transform.position = batMovement.startPoint.transform.position;
        batMovement.finished = false;
        
        jaw.transform.DOLocalMove(jawDown, 1).SetEase(Ease.OutBounce).OnComplete(() => vampire.Move()); 
        
        countDown = timer;
        countingDown = true;
        ScoreManager.Instance.ResetScore();
        objectsToActivate.SetActive(true);
    }

    void CountDownEnd()
    {
        countingDown = false;
        vampire.moving = false;
        jaw.transform.DOLocalMove(jawUp, 1);
        objectsToActivate.SetActive(false);
        timerText.text = "Time: " + 0;
    }
}
