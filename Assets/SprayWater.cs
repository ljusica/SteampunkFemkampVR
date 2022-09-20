using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprayWater : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public ParticleSystem waterHitParticle;

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
            forwardPoint = hit.transform.position;
        }
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        lineRenderer.SetPosition(1, forwardPoint);
        lineRenderer.enabled = true;
        waterHitParticle.gameObject.SetActive(true);
        waterHitParticle.transform.position = forwardPoint;
    }
    public void ReleaseSpray()
    {
        isSpraying = false;
        lineRenderer.enabled = false;
        waterHitParticle.gameObject.SetActive(false);
    }
}
