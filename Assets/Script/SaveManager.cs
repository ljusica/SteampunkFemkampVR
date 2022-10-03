using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
class PentathlonData
{
    public bool hasPlayedEyeBall; 
    public bool hasPlayedClubTheCub;
    public bool hasPlayedBloodlust;
    public bool hasPlayedTeddyKnockdown;
    public bool hasPlayedSkullHunt;
}

public class SaveManager : MonoBehaviour
{
    public bool hasPlayedEyeBall;
    public bool hasPlayedClubTheCub;
    public bool hasPlayedBloodlust;
    public bool hasPlayedTeddyKnockdown;
    public bool hasPlayedSkullHunt;

    private PentathlonData pentathlonData;

    private static SaveManager instance;
    public static SaveManager Instance { get { return instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Load();
        yield return new WaitForSecondsRealtime(20f);

        switch (SceneManager.GetActiveScene().name)
        {
            case "EyeBall":
                //s�tt skeeball bool
                hasPlayedEyeBall = true;
                break;
            case "SkullHunt":
                //s�tt duckhunt bool
                hasPlayedSkullHunt = true;
                break;
            case "TeddyKnockDown":
                //s�tt dtc bool
                hasPlayedTeddyKnockdown = true;
                break;
            case "Bloodlust":
                //s�tt TR bool
                hasPlayedBloodlust = true;
                break;
            case "ClubTheCub":
                //s�tt WAM bool
                hasPlayedClubTheCub = true;
                break;
        }
        Save();
    }

    void Save()
    {
        pentathlonData = new PentathlonData();

        pentathlonData.hasPlayedEyeBall = hasPlayedEyeBall;
        pentathlonData.hasPlayedBloodlust = hasPlayedBloodlust;
        pentathlonData.hasPlayedClubTheCub = hasPlayedClubTheCub;
        pentathlonData.hasPlayedSkullHunt = hasPlayedSkullHunt;
        pentathlonData.hasPlayedTeddyKnockdown = hasPlayedTeddyKnockdown;

        string jsonString = JsonUtility.ToJson(pentathlonData);

        //For now just save it using PlayerPrefs
        PlayerPrefs.SetString("PentathlonData", jsonString);
    }

    void Load()
    {
        string jsonString = PlayerPrefs.GetString("PentathlonData");
        PentathlonData loadedData = JsonUtility.FromJson<PentathlonData>(jsonString);

        if (loadedData == null){return;}

        hasPlayedEyeBall = loadedData.hasPlayedEyeBall;
        hasPlayedBloodlust = loadedData.hasPlayedBloodlust;
        hasPlayedClubTheCub = loadedData.hasPlayedClubTheCub;
        hasPlayedSkullHunt = loadedData.hasPlayedSkullHunt;
        hasPlayedTeddyKnockdown = loadedData.hasPlayedTeddyKnockdown;
    }
}
