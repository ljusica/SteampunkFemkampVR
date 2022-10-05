using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayTeddyFlipSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;
    [SerializeField]
    AudioSource audioSource;

    FlipClown[] flipClowns;
    void Start()
    {
        flipClowns.AddRange(GetComponentsInChildren<FlipClown>());
        foreach (var FlipClown in flipClowns)
        {
            FlipClown.onFlip += PlayHitSound;
        }
    }

    void PlayHitSound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
