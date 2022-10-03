using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWater : MonoBehaviour
{
    public ParticleSystem waterHitParticle;
    public BatMovement batMovement;

    public void StartSpraying()
    {
        waterHitParticle.gameObject.SetActive(true);
    }

    public void ReleaseSpray()
    {
        waterHitParticle.gameObject.SetActive(false);
    }
}
