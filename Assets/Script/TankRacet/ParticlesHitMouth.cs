using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHitMouth : MonoBehaviour
{
    public BatMovement batMovement;
    public ParticleSystem ps;
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
        }
    }
}
