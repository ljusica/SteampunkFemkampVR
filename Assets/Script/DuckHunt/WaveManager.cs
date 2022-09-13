using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float amplitude = 1;
    public float length = 2;
    public float speed = 5;
    public float offset = 0;
    public float xDown;

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset) -xDown;
    }
}
