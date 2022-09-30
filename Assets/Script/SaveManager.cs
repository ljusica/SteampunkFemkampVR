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
            case "SkeeBall":
                //sätt skeeball bool
                hasPlayedEyeBall = true;
                break;
            case "DuckHunt":
                //sätt duckhunt bool
                hasPlayedSkullHunt = true;
                break;
            case "DTC":
                //sätt dtc 
                hasPlayedTeddyKnockdown = true;
                break;
            case "TankRacet":
                //sätt TR bool
                hasPlayedBloodlust = true;
                break;
            case "WAM":
                //sätt WAM bool
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

        hasPlayedEyeBall = loadedData.hasPlayedEyeBall;
        hasPlayedBloodlust = loadedData.hasPlayedBloodlust;
        hasPlayedClubTheCub = loadedData.hasPlayedClubTheCub;
        hasPlayedSkullHunt = loadedData.hasPlayedSkullHunt;
        hasPlayedTeddyKnockdown = loadedData.hasPlayedTeddyKnockdown;
    }
}
