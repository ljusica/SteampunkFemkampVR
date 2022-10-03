using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHappyVoiceLines : MonoBehaviour
{
    [SerializeField]
    VoiceLinesPlayer voiceLine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceLine.PlayMockLine();
        }
    }
}
