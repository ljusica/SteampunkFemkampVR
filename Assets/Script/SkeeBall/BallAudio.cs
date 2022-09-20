using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ball") || !collision.gameObject.CompareTag("Table"))
            audioSource.Play();
    }
}
