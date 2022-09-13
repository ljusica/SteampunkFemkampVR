using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameIsOver : MonoBehaviour
{
    public TMP_Text ScoreText;


    //ScoreText to other scene, bring score.
    void Start()
    {
        ScoreText.text = ScoreKeeper.Score.ToString();
    }
}
