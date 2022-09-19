using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    public float skeeBallScore = 0;
    public float duckHuntScore = 0;
    public float dtcScore = 0;
    public float tankRacetScore = 0;
    public float wamScore = 0;

    //private static float hScore;
    //public static float HighScore { get { return hScore; } }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        CreateSavedScores();

        //if (!PlayerPrefs.HasKey("HighScore"))
        //    PlayerPrefs.SetFloat("HighScore", 0);
        //else
        //    hScore = PlayerPrefs.GetFloat("HighScore");
    }

    public void AddScore(string gameName, float score)
    {
        switch (gameName)
        {
            case "SkeeBall":
                skeeBallScore += score;
                break;
            case "DuckHunt":
                duckHuntScore += score;
                break;
            case "DTC":
                dtcScore += score;
                break;
            case "TankRacet":
                tankRacetScore += score;
                break;
            case "WAM":
                wamScore += score;
                break;
        }
    }

    public void SetHighScore(string gameName, float currentScore)
    {
        if(currentScore > PlayerPrefs.GetFloat(gameName))
            PlayerPrefs.SetFloat(gameName, currentScore);
        PlayerPrefs.Save();
    }

    public float GetHighScore(string gameName)
    {
        return PlayerPrefs.GetFloat(gameName);
    }

    private void CreateSavedScores()
    {
        if (!PlayerPrefs.HasKey("SkeeBall"))
            PlayerPrefs.SetFloat("SkeeBall", 0);
        if (!PlayerPrefs.HasKey("DuckHunt"))
            PlayerPrefs.SetFloat("DuckHunt", 0);
        if (!PlayerPrefs.HasKey("DownTheClown"))
            PlayerPrefs.SetFloat("DownTheClown", 0);
        if (!PlayerPrefs.HasKey("TankRacet"))
            PlayerPrefs.SetFloat("TankRacet", 0);
        if (!PlayerPrefs.HasKey("WhacAMole"))
            PlayerPrefs.SetFloat("WhacAMole", 0);

        PlayerPrefs.Save();
    }

    private void OnLevelWasLoaded(int level)
    {
        skeeBallScore = 0;
        duckHuntScore = 0;
        dtcScore = 0;
        tankRacetScore = 0;
        wamScore = 0;
    }
}
