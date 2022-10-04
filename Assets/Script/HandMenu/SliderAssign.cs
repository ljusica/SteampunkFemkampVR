using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAssign : MonoBehaviour
{
    public string whichSlider;
    public Slider slider;

    private void OnEnable()
    {
        AudioManager.Instance.OnMenuEnable(slider, whichSlider);

        switch (whichSlider)
        {
            case "Master":
                slider.value = LoadVolumeSettings.volumeSettings.masterVolume;
                break;

            case "SFX":
                slider.value = LoadVolumeSettings.volumeSettings.sfxVolume;
                break;

            case "Music":
                slider.value = LoadVolumeSettings.volumeSettings.musicVolume;
                break;

            case "Voiceline":
                slider.value = LoadVolumeSettings.volumeSettings.voicelineVolume;
                break;

            default:
                slider.value = 0.5f;
                break;
        }
    }
}
