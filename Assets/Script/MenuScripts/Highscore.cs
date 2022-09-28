using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshPro skeeballText;
    public TextMeshPro duckhuntText;
    public TextMeshPro wamText;
    public TextMeshPro dtcText;
    public TextMeshPro tankracetText;

    float skeeballHighscore;
    float duckhuntHighscore;
    float wamHighscore;
    float dtcHighscore;
    float tankracetHighscore;

    void Start()
    {
        skeeballHighscore = ScoreManager.Instance.GetHighScore("SkeeBall");
        duckhuntHighscore = ScoreManager.Instance.GetHighScore("DuckHunt");
        wamHighscore = ScoreManager.Instance.GetHighScore("WhacAMole");
        dtcHighscore = ScoreManager.Instance.GetHighScore("DownTheClown");
        tankracetHighscore = ScoreManager.Instance.GetHighScore("TankRacet");

        skeeballText.text = skeeballHighscore.ToString();
        duckhuntText.text = duckhuntHighscore.ToString();
        wamText.text = wamHighscore.ToString();
        dtcText.text = dtcHighscore.ToString();
        tankracetText.text = tankracetHighscore.ToString();
    }

}
