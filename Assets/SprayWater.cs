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
    public void StartSpraying()
    {
        InvokeRepeating(nameof(Spray),0,0.05f);
    }
    public void Spray()
    {
        Physics.Raycast(transform.position,transform.forward,out RaycastHit hit, 30);
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        lineRenderer.SetPosition(1, hit.point);
        lineRenderer.enabled = true;
        waterHitParticle.gameObject.SetActive(true);
        waterHitParticle.transform.position = hit.point;
    }
    public void ReleaseSpray()
    {
        CancelInvoke(nameof(Spray));
        lineRenderer.enabled = false;
        waterHitParticle.gameObject.SetActive(false);
    }
}
