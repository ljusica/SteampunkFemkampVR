using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SprayWater : MonoBehaviour
{
    public ParticleSystem waterHitParticle;

    [SerializeField]
    AudioSource sprayAudio;
    ParticleSystem.EmissionModule emissionModule;

    private void Start()
    {
        emissionModule = waterHitParticle.emission;
    }
    public void StartSpraying()
    {
        emissionModule.enabled = true;
        sprayAudio.enabled = true;
    }

    public void ReleaseSpray()
    {
        emissionModule.enabled = false;
        sprayAudio.enabled = false;
    }
}
