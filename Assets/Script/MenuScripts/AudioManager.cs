using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public AudioMixer audioMixer;

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
        float toggleAudio = MathF.Log10(0.0001f) * 20;

        audioMixer.SetFloat("SfxVolume", sfxVolumeConvert);
        audioMixer.SetFloat("MusicVolume", musicVolumeConvert);
        if (!savedSettings.isSfxOn) audioMixer.SetFloat("SfxVolume", toggleAudio);
        if (!savedSettings.isMusicOn) audioMixer.SetFloat("MusicVolume", toggleAudio);
    }

    public void TestSetVolume(float value)
    {
        float volume = MathF.Log10(value) * 20;
        audioMixer.SetFloat("MusicVolume", volume);
    }
}
