using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBall : MonoBehaviour
{
    private Rigidbody ballRB;

    private void Boost()
    {
        if (ballRB.velocity.z < 6 && ballRB.velocity.z > 1.75)
        {
            Vector3 vel = ballRB.velocity;
            vel.z += 1f;
            ballRB.velocity = vel;
            Debug.Log("Boosting!");

            float targetAngleY = Mathf.Atan2(ballRB.velocity.y, ballRB.velocity.z) * Mathf.Rad2Deg + transform.rotation.eulerAngles.z;

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
