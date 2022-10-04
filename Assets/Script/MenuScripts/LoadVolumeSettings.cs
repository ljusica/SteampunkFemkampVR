using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class LoadVolumeSettings : MonoBehaviour
{
    public static VolumeSettings volumeSettings;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.DeleteKey("Volume");

        if (PlayerPrefs.HasKey("Volume"))
        {
            string jsonString = PlayerPrefs.GetString("Volume");
            volumeSettings = JsonUtility.FromJson<VolumeSettings>(jsonString);
        }
        else
        {
            VolumeSettings defaultSettings = new VolumeSettings
            { isMusicOn = true, isSfxOn = true, isVoicelineOn = true, isMasterOn = true,
                musicVolume = 0.5f, sfxVolume = 0.5f, voicelineVolume = 0.5f, masterVolume = 0.5f};

            string jsonString = JsonUtility.ToJson(defaultSettings);
            PlayerPrefs.SetString("Volume", jsonString);
            PlayerPrefs.Save();
            volumeSettings = defaultSettings;
        }
    }
}
