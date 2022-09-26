using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprayWater : MonoBehaviour
{
    public ParticleSystem waterHitParticle;
    public BatMovement batMovement;

    TestControlls controller;
    InputAction shoot;
    Vector3 forwardPoint;
    private bool isSpraying;

    private void FixedUpdate()
    {
        if (isSpraying)
        {
            Spray();
        }
    }

    public void StartSpraying()
    {
        isSpraying = true;
    }

    public void Spray()
    {
        waterHitParticle.gameObject.SetActive(true);
        waterHitParticle.transform.position = forwardPoint;
        print("Spraying!");
    }

    public void ReleaseSpray()
    {
        isSpraying = false;
        waterHitParticle.gameObject.SetActive(false);
    }
}
