using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    public Slider voicelineSlider;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        ApplyAudioSettings();
    }

    private void ApplyAudioSettings()
    {
        VolumeSettings savedSettings = LoadVolumeSettings.volumeSettings;
        float sfxVolumeConvert = MathF.Log10(savedSettings.sfxVolume) * 20;
        float musicVolumeConvert = MathF.Log10(savedSettings.musicVolume) * 20;
        float masterVolumeConvert = MathF.Log10(savedSettings.masterVolume) * 20;
        float voicelineVolumeConvert = MathF.Log10(savedSettings.voicelineVolume) * 20;
        float toggleAudio = MathF.Log10(0.0001f) * 20;

        audioMixer.SetFloat("SfxVolume", sfxVolumeConvert);
        audioMixer.SetFloat("MusicVolume", musicVolumeConvert);
        audioMixer.SetFloat("MasterVolume", masterVolumeConvert);
        audioMixer.SetFloat("VoicelineVolume", voicelineVolumeConvert);
        if (!savedSettings.isSfxOn) audioMixer.SetFloat("SfxVolume", toggleAudio);
        if (!savedSettings.isMusicOn) audioMixer.SetFloat("MusicVolume", toggleAudio);
        if (!savedSettings.isMasterOn) audioMixer.SetFloat("MasterVolume", toggleAudio);
        if (!savedSettings.isVoicelineOn) audioMixer.SetFloat("VoicelineVolume", toggleAudio);
    }

    public void UpdateMusicVolume(float value)
    {
        float volume = MathF.Log10(value) * 20;
        LoadVolumeSettings.volumeSettings.musicVolume = volume;
        audioMixer.SetFloat("MusicVolume", volume);
        string jsonString = JsonUtility.ToJson(LoadVolumeSettings.volumeSettings);
        PlayerPrefs.SetString("Volume", jsonString);
        PlayerPrefs.Save();
    }

    public void UpdateSfxVolume(float value)
    {
        float volume = MathF.Log10(value) * 20;
        LoadVolumeSettings.volumeSettings.sfxVolume = volume;
        audioMixer.SetFloat("SfxVolume", volume);
        string jsonString = JsonUtility.ToJson(LoadVolumeSettings.volumeSettings);
        PlayerPrefs.SetString("Volume", jsonString);
        PlayerPrefs.Save();
    }
    public void UpdateMasterVolume(float value)
    {
        float volume = MathF.Log10(value) * 20;
        LoadVolumeSettings.volumeSettings.masterVolume = volume;
        audioMixer.SetFloat("MasterVolume", volume);
        string jsonString = JsonUtility.ToJson(LoadVolumeSettings.volumeSettings);
        PlayerPrefs.SetString("Volume", jsonString);
        PlayerPrefs.Save();
    }
    public void UpdateVoicelineVolume(float value)
    {
        float volume = MathF.Log10(value) * 20;
        LoadVolumeSettings.volumeSettings.voicelineVolume = volume;
        audioMixer.SetFloat("VoicelineVolume", volume);
        string jsonString = JsonUtility.ToJson(LoadVolumeSettings.volumeSettings);
        PlayerPrefs.SetString("Volume", jsonString);
        PlayerPrefs.Save();
    }

    public void OnMenuEnable(Slider slider, string type)
    {
        switch (type)
        {
            case "Music":
                musicSlider = slider;
                musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
                break;

            case "SFX":
                sfxSlider = slider;
                sfxSlider.onValueChanged.AddListener(UpdateSfxVolume);
                break;

            case "Voiceline":
                voicelineSlider = slider;
                voicelineSlider.onValueChanged.AddListener(UpdateVoicelineVolume);
                break;

            case "Master":
                masterSlider = slider;
                masterSlider.onValueChanged.AddListener(UpdateMasterVolume);
                break;
        }
    }
}
