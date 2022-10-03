using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWelcomeSoundOnce : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    static bool alreadyPlayed = false;
    private void Start()
    {
        if (!alreadyPlayed)
        {
            audioSource.Play();
            alreadyPlayed = true;
        }
    }
}
