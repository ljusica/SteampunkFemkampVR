using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1;
    public float length = 2;
    public float speed = 1;
    public float offset = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
