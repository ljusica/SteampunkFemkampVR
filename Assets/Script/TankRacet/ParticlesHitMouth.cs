using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ParticlesHitMouth : MonoBehaviour
{
    public BatMovement batMovement;
    public ParticleSystem ps;
    public AudioSource hitMouthSound;
    public GameObject bloodDecal;
    public List<Material> bloodMaterials;
    public GameObject vampire;

    List<ParticleSystem.Particle> particles;
    bool bloodSplattered = false;
    private void Start()
    {
        particles = new List<ParticleSystem.Particle>();
    }
    private void OnParticleTrigger()
    {
        if(ParticlePhysicsExtensions.GetTriggerParticles(ps, ParticleSystemTriggerEventType.Enter, particles) > 0)
        {
            batMovement.Move();
            if (!hitMouthSound.isPlaying)
            {
                hitMouthSound.pitch += 0.2f;
                hitMouthSound.Play();
            }
        }
    }
    IEnumerator SpawnBloodDecal(GameObject other)
    {
        bloodSplattered = true;
        GameObject decal = Instantiate(bloodDecal);
        decal.transform.position = particles[0].position;
        decal.transform.parent = other.transform;
        decal.GetComponent<DecalProjector>().material = bloodMaterials[Random.Range(0, bloodMaterials.Count)];
        yield return new WaitForSeconds(0.5f);
        bloodSplattered = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!bloodSplattered)
        {
            SpawnBloodDecal(other);
        }
    }
}
