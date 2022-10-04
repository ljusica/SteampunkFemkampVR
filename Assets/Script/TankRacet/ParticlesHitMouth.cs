using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHitMouth : MonoBehaviour
{
    public BatMovement batMovement;
    public ParticleSystem ps;
    public AudioSource hitMouthSound;
    List<ParticleSystem.Particle> particles;
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
}
