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
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 30))
        {
            forwardPoint = transform.forward * 30;
        }
        else
        {
            forwardPoint = hit.point;
            //if (hit.transform.tag == "Mouth")
            //{
            //    batMovement.Move();
            //}
        }

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
