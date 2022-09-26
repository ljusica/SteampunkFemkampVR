using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHitMouth : MonoBehaviour
{
    public BatMovement batMovement;
    public ParticleSystem ps;
    private void OnParticleCollision(GameObject other)
    {
        batMovement.Move();
    }
}
