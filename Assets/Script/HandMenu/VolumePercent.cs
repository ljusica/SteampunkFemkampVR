using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumePercent : MonoBehaviour
{
    private TMP_Text text;
    public Slider slider;
    string percentageText;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        slider.onValueChanged.AddListener(UpdatePercentage);
    }

    void UpdatePercentage(float value)
    {
        text.text = string.Format("{0:0%}", value);
    }
}
