using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAssign : MonoBehaviour
{
    public string whichSlider;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        switch (whichSlider)
        {
            case "Music":
                AudioManager.Instance.musicSlider = gameObject.GetComponent<Slider>();
                slider.onValueChanged.AddListener(AudioManager.Instance.UpdateMusicVolume);
                break;

            case "SFX":
                AudioManager.Instance.sfxSlider = gameObject.GetComponent<Slider>();
                slider.onValueChanged.AddListener(AudioManager.Instance.UpdateSfxVolume);
                break;
        }
    }
}
