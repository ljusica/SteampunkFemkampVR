using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHitMouth : MonoBehaviour
{
    public BatMovement batMovement;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Bat moving");
        //batMovement.Move();
    }
}
