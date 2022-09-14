using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBall : MonoBehaviour
{
    private Rigidbody ballRB;
    public float boostMultiplier;
    public float boostMin;
    public float boostMax;

    private void Boost()
    {
        if (ballRB.velocity.z < boostMax && ballRB.velocity.z > boostMin)
        {
            Vector3 vel = ballRB.velocity;
            vel.z += boostMultiplier;
            vel.y += boostMultiplier * 0.75f;
            ballRB.velocity = vel;
            Debug.Log("Boosting!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag =="Ball")
        {
            Debug.Log(other.gameObject.GetComponent<Rigidbody>().velocity);
            ballRB = other.gameObject.GetComponent<Rigidbody>();
            Boost();
        }
    }
}
