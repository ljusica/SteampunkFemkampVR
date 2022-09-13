using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public GameObject[] ducks;
    private float[] ducksX;

    public WaveManager waveManager;

    public float depthBeforeSubmerged = 1;
    public float displacementAmount = 3;

    private Rigidbody rb;

    private void Start()
    {
        ducksX = new float[ducks.Length];
        for(int i = 0; i < ducks.Length; i++)
        {
            ducksX[i] = ducks[i].transform.position.x;
        }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < ducks.Length; i++)
        {
            rb = ducks[i].GetComponent<Rigidbody>();
            float waveHeight = waveManager.GetWaveHeight(ducksX[i]);

            if (ducks[i].transform.position.y < waveHeight)
            {
                float displacementMultiplier = Mathf.Clamp01((waveHeight - ducks[i].transform.position.y) / depthBeforeSubmerged) * displacementAmount;
                rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
            }
        }

    }

}
