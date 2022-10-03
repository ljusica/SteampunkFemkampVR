using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballScoreAudioHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> clownLaughClips;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            audioSource.clip = clownLaughClips[Random.Range(0, clownLaughClips.Count)];
            audioSource.Play();
        }
    }
}
