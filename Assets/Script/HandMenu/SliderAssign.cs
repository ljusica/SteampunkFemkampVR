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
    }

    private void OnDisable()
    {
        AudioManager.Instance.OnMenuDisable();
    }
}
